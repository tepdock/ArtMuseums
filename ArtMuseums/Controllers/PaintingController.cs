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
    [Route("api/paintings")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PaintingController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPaintings()
        {
            var paintings = _repository.PaintingRepository.GetAllPaintings(trackChanges: false);

            var paintingsDto = _mapper.Map<IEnumerable<PaintingDto>>(paintings);

            return Ok(paintingsDto);
        }

        [HttpGet("artist/{id}")]
        public IActionResult GetPaintingsByArtist(Guid artistId)
        {
            var artist = _repository.ArtistRepository.GetArtist(artistId, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"artist with id: {artistId} doesnt exist");
                return NotFound();
            }

            var paintigs = _repository.PaintingRepository.GetPaintingsByAuthor(artistId, trackChanges: false);

            var paintingsDto = _mapper.Map<IEnumerable<PaintingDto>>(paintigs);

            return Ok(paintingsDto);
        }

        [HttpGet("{id}", Name = "GetPaintingById")]
        public IActionResult GetPainting(Guid id)
        {
            var painting = _repository.PaintingRepository.GetPaintingById(id, trackChanges: false);

            if(painting == null)
            {
                _logger.Info($"painting with id: {id} doesnt exist");
                return NotFound();
            }
            else
            {
                var paintingDto = _mapper.Map<PaintingDto>(painting);
                return Ok(paintingDto);
            }
        }

        [HttpGet("exhibition/{exhibitionId}")]
        public IActionResult GetPaintingInExhibition(Guid exhibitionId)
        {
            var paintings = _repository.PaintingRepository.GetPaintingsByExhibition(exhibitionId, trackChanges: false);

            var paintingDto = _mapper.Map<IEnumerable<PaintingDto>>(paintings);

            return Ok(paintingDto);
        }

        [HttpGet("name/{Name}")]
        public IActionResult GetPaintingsByName(string name)
        {
            var paintings = _repository.PaintingRepository.GetPaintingsByName(name, trackChanges: false);   

            var paintingDto = _mapper.Map<IEnumerable<PaintingDto>>(paintings);

            return Ok(paintingDto);
        }

        [HttpPost]
        public IActionResult CreatePainting([FromBody] PaintingForCreationDto painting) 
        {
            if (painting == null)
            {
                _logger.Error("PaintingForCreationDto object sent by client is null");
                return BadRequest("PaintingForCreationDto object is null");
            }

            var paintingEntity = _mapper.Map<Painting>(painting);

            _repository.PaintingRepository.CreatePainting(paintingEntity);
            _repository.Save();

            var paintingForReturn = _mapper.Map<PaintingDto>(paintingEntity);

            return CreatedAtRoute("GetPaintingById", new {id = paintingForReturn.Id}, paintingForReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePainting(Guid id)
        {
            var painting = _repository.PaintingRepository.GetPaintingById(id, trackChanges: false);
            if(painting == null)
            {
                _logger.Info($"Paiting with id: {id} does not exist");
                return NotFound();
            }

            _repository.PaintingRepository.DeletePainting(painting);
            _repository.Save();

            return NoContent();
        }
    }
}
