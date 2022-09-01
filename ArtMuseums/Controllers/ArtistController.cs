using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetArtists([FromQuery] ArtistsParameters artistsParameters)
        {
            var artists = await _repository.ArtistRepository.GetAllArtists(artistsParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(artists.MetaData));

            var artistsDto = _mapper.Map<IEnumerable<ArtistDto>>(artists);

            return Ok(artistsDto);
        }

        [HttpGet("{id}", Name = "ArtistById")]
        public async Task<IActionResult> GetArtist(Guid id)
        {
            var artist = await _repository.ArtistRepository.GetArtist(id, trackChanges: false);
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

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateArtist([FromBody]ArtistForCreationDto artist)
        {
            var artistEntity = _mapper.Map<Artist>(artist);

            _repository.ArtistRepository.CreateArtist(artistEntity);
            await _repository.SaveAsync();

            var artistToReturn = _mapper.Map<ArtistDto>(artistEntity);

            return CreatedAtRoute("ArtistById", new {id = artistToReturn.Id}, artistToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(Guid id)
        {
            var artist = await _repository.ArtistRepository.GetArtist(id, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"Artist with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.ArtistRepository.DeleteArtist(artist);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateArtist(Guid id, [FromBody] ArtistForUpdateDto artist)
        {
            var artistEntity = await _repository.ArtistRepository.GetArtist(id, trackChanges: true);
            if(artistEntity == null)
            {
                _logger.Info($"artist with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(artist, artistEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
