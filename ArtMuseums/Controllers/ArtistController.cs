using ArtMuseum;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArtMuseums.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ArtistController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetArtists()
        {
            var artists = _repository.ArtistRepository.GetAllArtists(trackChanges: false);

            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artists);

            return Ok(artistsDto);
        }

        [HttpGet("{id}", Name = "ArtistById")]
        public IActionResult GetArtist(Guid id)
        {
            var artist = _repository.ArtistRepository.GetArtist(id, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"Artist with id: {id} doesn't exist");
                return NotFound();
            }
            else
            {
                var artistDto = _mapper.Map<ArtistDto>(artist);
                return Ok(artistDto);
            }
        }

        [HttpGet("country/{country}")]
        public IActionResult GetArtistBycountry(string country)
        {
            var artists = _repository.ArtistRepository.GetAllArtistsByCountry(country, trackChanges: false);

            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artists);
            return Ok(artistsDto);
       
        }

        [HttpGet("name/{name}")]
        public IActionResult GetArtistByName(string name)
        {
            var artist = _repository.ArtistRepository.GetArtistByName(name, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"Artist with name: {name} doesn't exist");
                return NotFound();
            }
            else
            {
                var artistDto = _mapper.Map<ArtistDto>(artist);
                return Ok(artistDto);
            }
        }

        [HttpPost]
        public IActionResult CreateArtist([FromBody]ArtistForCreationDto artist)
        {
            if(artist == null)
            {
                _logger.Error("ArtistForCreationDto object sent from client is null");
                return BadRequest("ArtistForCreationDto object is null");
            }

            var artistEntity = _mapper.Map<Artist>(artist);

            _repository.ArtistRepository.CreateArtist(artistEntity);
            _repository.Save();

            var artistToReturn = _mapper.Map<ArtistDto>(artistEntity);

            return CreatedAtRoute("ArtistById", new {id = artistToReturn.Id}, artistToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(Guid id)
        {
            var artist = _repository.ArtistRepository.GetArtist(id, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"Artist with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.ArtistRepository.DeleteArtist(artist);
            _repository.Save();

            return NoContent();
        }
    }
}
