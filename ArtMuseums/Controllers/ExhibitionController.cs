using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/museums/{museumId}/exhibitions")]
    [ApiController]
    public class ExhibitionController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ExhibitionController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetExhibitions(Guid museumId, [FromQuery] ExhibitionsParameters exhibitionsParameters)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"meseum with id: {museumId} doesnt exist");
                return NotFound();
            }

            var exhibitions = await _repository.ExhibitionRepository.GetAllExhibitions(museumId, exhibitionsParameters,
                trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(exhibitions.MetaData));

            var exhibitionsDto = _mapper.Map<IEnumerable<ExhibitionDto>>(exhibitions);

            return Ok(exhibitionsDto);
        }

        [HttpGet("{id}", Name = "GetExhibitionById")]
        public async Task<IActionResult> GetExhibition(Guid museumId, Guid id)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"Museum with id: {museumId} doesn't exist");
                return NotFound();
            }

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, id, trackChanges: false);
            if (exhibition == null)
            {
                _logger.Info($"exhibition with id: {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var exhibitionDto = _mapper.Map<ExhibitionDto>(exhibition);
                return Ok(exhibitionDto);
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateExhibitionForMuseum(Guid museumId, [FromBody]
        ExhibitionForCreationDto exhibition)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"Museum with id: {museumId} doesnt exist");
                return NotFound();
            }

            var exhibitionEntity = _mapper.Map<Exhibition>(exhibition);

            _repository.ExhibitionRepository.CreateExhibition(museumId, exhibitionEntity);
            await _repository.SaveAsync();

            var exhibitionForReturn = _mapper.Map<ExhibitionDto>(exhibitionEntity);

            return CreatedAtRoute("GetExhibitionById", new { museumId, id = exhibitionForReturn.Id },
                exhibitionForReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExhibition(Guid museumId, Guid id)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"Museum with id: {museumId} does not exist");
                return NotFound();
            }

            var exhibition = await _repository.ExhibitionRepository.GetExhibition(museumId, id, trackChanges: false);
            if (exhibition == null)
            {
                _logger.Info($"Exhibition with id: {id} does not exist");
                return NotFound();
            }

            _repository.ExhibitionRepository.DeleteExhibition(museumId, exhibition);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateExhibition(Guid museumId, Guid id,
            [FromBody] ExhibitionForUpdateDto exhibition)
        { 
            var museum = await _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"museum with id: {museumId} doesn't exist");
                return NotFound();
            }

            var exhibitionEntity = await _repository.ExhibitionRepository.GetExhibition(museumId, id, trackChanges: true);
            if(exhibitionEntity == null)
            {
                _logger.Info($"exhibition with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(exhibition, exhibitionEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
