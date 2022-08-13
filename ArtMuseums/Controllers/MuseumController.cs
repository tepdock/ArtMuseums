using ArtMuseum;
using AutoMapper;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArtMuseums.Controllers
{
    [Route("api/museums")]
    [ApiController]
    public class MuseumController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MuseumController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMuseums()
        {
            var museums = _repository.ArtMuseumRepository.GetAllMuseums(trackChanges: false);

            var museumsDto = _mapper.Map<IEnumerable<MuseumDto>>(museums);

            return Ok(museumsDto);
        }

        [HttpGet("{id}", Name = "GetMuseumById")]
        public IActionResult GetMuseum(Guid id)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseum(id, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"museum with id: {id} does not exist");
                return NotFound();
            }
            else
            {
                var museumDto = _mapper.Map<MuseumDto>(museum);
                return Ok(museumDto);
            }
        }

        [HttpGet("name/{name}")]
        public IActionResult GetMuseumByName(string name)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseumByName(name, trackChanges: false);
            if(museum == null)
            {
                _logger.Info($"museum with name: {name} doesn't exist");
                return NotFound();
            }
            else
            {
                var museumDto = _mapper.Map<MuseumDto>(museum);
                return Ok(museumDto);
            }
        }

        [HttpPost]
        public IActionResult CreateMuseum([FromBody] MuseumForCreationDto museum) 
        { 
            if(museum == null)
            {
                _logger.Error("MuseumForCreationDto object sent by client is null");
                return BadRequest("MuseumForCreationDto object is null");
            }

            var museumEntity = _mapper.Map<Entities.Models.ArtMuseum>(museum);

            _repository.ArtMuseumRepository.CreateMuseum(museumEntity);
            _repository.Save();

            var museumForReturn = _mapper.Map<MuseumDto>(museumEntity);

            return CreatedAtRoute("GetMuseumById", new {id = museumForReturn.Id}, museumForReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMuseum(Guid id)
        {
            var museum = _repository.ArtMuseumRepository.GetMuseum(id, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"museum with id: {id} does not exist");
                return NotFound();
            }

            _repository.ArtMuseumRepository.DeleteMuseum(museum);
            _repository.Save();

            return NoContent();
        }
    }
}
