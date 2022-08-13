using ArtMuseum;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetExhibitions(Guid museumId)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"meseum with id: {museumId} doesnt exist");
                return NotFound();
            }

            var exhibitions = _repository.ExhibitionRepository.GetAllExhibitions(museumId, trackChanges: false);

            var exhibitionsDto = _mapper.Map<IEnumerable<ExhibitionDto>>(exhibitions);

            return Ok(exhibitionsDto);
        }

        [HttpGet("{id}", Name = "GetExhibitionById")]
        public IActionResult GetExhibition(Guid museumId, Guid id)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"Museum with id: {museumId} doesn't exist");
                return NotFound();
            }

            var exhibition = _repository.ExhibitionRepository.GetExhibition(museumId, id, trackChanges: false);
            if(exhibition == null)
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
        public IActionResult CreateExhibitionForMuseum(Guid museumId, [FromBody]
        ExhibitionForCreationDto exhibition)
        {
            if (exhibition == null) 
            {
                _logger.Error("ExhibitionForCreationDto object sent from client is null");
                return BadRequest("ExhibitionForCreationDto is null");
            }

            var museum = _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"Museum with id: {museumId} doesnt exist");
                return NotFound();
            }

            var exhibitionEntity = _mapper.Map<Exhibition>(exhibition);

            _repository.ExhibitionRepository.CreateExhibition(museumId, exhibitionEntity);
            _repository.Save();

            var exhibitionForReturn = _mapper.Map<ExhibitionDto>(exhibitionEntity);

            return CreatedAtRoute("GetExhibitiobById", new { museumId, id = exhibitionForReturn.Id }, 
                exhibitionForReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExhibition(Guid museumId, Guid id)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseum(museumId, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"Museum with id: {museumId} does not exist");
                return NotFound();
            }

            var exhibition = _repository.ExhibitionRepository.GetExhibition(museumId, id, trackChanges: false);
            if(exhibition == null)
            {
                _logger.Info($"Exhibition with id: {id} does not exist");
                return NotFound();
            }

            _repository.ExhibitionRepository.DeleteExhibition(museumId, exhibition);
            _repository.Save();

            return NoContent();
        }
    }
}
