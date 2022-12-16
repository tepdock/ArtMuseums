using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/exhibitions/{exhibitionId}/tours")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TourController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTours(string exhibitionId, [FromQuery] ToursParameters toursParameters)
        {
            if (!toursParameters.ValidPlacesRange)
                return BadRequest("Max places can't be less than min places");

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            if (exhibition == null)
            {
                _logger.Info($"exhibition with id: {exhibitionId} doesn't exist");
                return NotFound();
            }

            var tours = await _repository.TourRepository.GetAllTours(exhibitionId, toursParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(tours.MetaData));

            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);

            return Ok(toursDto);
        }

        [HttpGet("{id}", Name = "GetTourById")]
        public async Task<IActionResult> GetTour(string exhibitionId, string tourId)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            if (exhibition == null)
            {
                _logger.Info($"exhibition with id: {exhibitionId} doesnt exist");
                return NotFound();
            }

            var tour = await _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if(tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesn't exist");
                return NotFound();
            }
            else
            {
                var tourDto = _mapper.Map<IEnumerable<TourDto>>(tour);
                return Ok(tourDto);
            }
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTour(string exhibitionId,
            [FromBody]TourForCreationDto tour)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            if(exhibition == null)
            {
                _logger.Info($"exhibition with id: {exhibitionId} doesn't exist");
                return NotFound();
            }

            tour.Id = Guid.NewGuid().ToString();
            var tourEntity = _mapper.Map<Tour>(tour);
            tourEntity.ExhibitionId = exhibitionId;
            _repository.TourRepository.CreateTour(tourEntity);
            await _repository.SaveAsync();

            var tourForReturn = _mapper.Map<TourDto>(tourEntity);

            return CreatedAtRoute("GetTourById", new { id = tourForReturn.Id }, tourForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTour(string id)
        {
            var tour = await _repository.TourRepository.GetTour(id, trackChanges: false);
            if(tour == null)
            {
                _logger.Info($"tour with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.TourRepository.DeleteTour(tour);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]        
        public async Task<IActionResult> UpdateTour(string exhibitionId, 
            string id, [FromBody] TourForUpdatingDto tour)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            if(exhibition == null)
            {
                _logger.Info($"exhibition with id: {exhibitionId} doesn't exist");
                return NotFound();
            }

            var tourEntity = await _repository.TourRepository.GetTour(id, trackChanges: true);
            if(tourEntity == null)
            {
                _logger.Info($"tour with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(tour, tourEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
