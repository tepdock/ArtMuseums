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
    [Route("api/museums/{museumId}/exhibitions/{exhibitionId}/tours")]
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
        public async Task<IActionResult> GetTours(Guid museumId, Guid exhibitionId, [FromQuery] ToursParameters toursParameters)
        {
            if (!toursParameters.ValidPlacesRange)
                return BadRequest("Max places can't be less than min places");

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, exhibitionId, trackChanges: false);
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
        public async Task<IActionResult> GetTour(Guid museumId, Guid exhibitionId, Guid tourId)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, exhibitionId, trackChanges: false);
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
        public async Task<IActionResult> CreateTour(Guid museumId, Guid exhibitionId,
            [FromBody]TourForCreationDto tour)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"museum with id: {museumId} doesn't exist");
                return NotFound();
            }

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, exhibitionId, trackChanges: false);
            if(exhibition == null)
            {
                _logger.Info($"exhibition with id: {exhibitionId} doesn't exist");
                return NotFound();
            }

            var tourEntity = _mapper.Map<Tour>(tour);
            _repository.TourRepository.CreateTour(tourEntity);
            await _repository.SaveAsync();

            var tourForReturn = _mapper.Map<TourDto>(tourEntity);

            return CreatedAtRoute("GetTourById", new { id = tourForReturn.Id }, tourForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTour(Guid id)
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
        public async Task<IActionResult> UpdateTour(Guid museumId, Guid exhibitionId, 
            Guid id, [FromBody] TourForUpdatingDto tour)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"museum with id: {museumId} doesn't exist");
                return NotFound();
            }

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, exhibitionId, trackChanges: false);
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
