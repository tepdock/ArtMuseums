using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetMuseums([FromQuery] MuseumParameters museumParameters)
        {
            var museums = await _repository.ArtMuseumRepository.GetAllMuseums(museumParameters, trackChanges: false);

            var museumsDto = _mapper.Map<IEnumerable<MuseumDto>>(museums);

            return Ok(museumsDto);
        }

        [HttpGet("{id}", Name = "GetMuseumById")]
        public async Task<IActionResult> GetMuseum(string id)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(id, trackChanges: false);
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

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMuseum([FromBody] MuseumForCreationDto museum) 
        { 
            var museumEntity = _mapper.Map<Entities.Models.ArtMuseum>(museum);

            _repository.ArtMuseumRepository.CreateMuseum(museumEntity);
            await _repository.SaveAsync();

            var museumForReturn = _mapper.Map<MuseumDto>(museumEntity);

            return CreatedAtRoute("GetMuseumById", new {id = museumForReturn.Id}, museumForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteMuseum(string id)
        {
            var museum = await _repository.ArtMuseumRepository.GetMuseum(id, trackChanges: false);
            if (museum == null)
            {
                _logger.Info($"museum with id: {id} does not exist");
                return NotFound();
            }

            _repository.ArtMuseumRepository.DeleteMuseum(museum);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMuseum(string id, [FromBody] MuseumForUpdateDto museum)
        {
            var museumEntity = await _repository.ArtMuseumRepository.GetMuseum(id, trackChanges: true);
            if(museumEntity == null)
            {
                _logger.Info($"museum with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(museum, museumEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
