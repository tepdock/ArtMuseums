using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetPaintings([FromQuery]
        PaintigsParameters paintigsParameters)
        {

            var paintings = await _repository.PaintingRepository.GetAllPaintings(paintigsParameters,
                trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(paintings.MetaData));

            var paintingsDto = _mapper.Map<IEnumerable<PaintingDto>>(paintings);

            return Ok(paintingsDto);
        }

        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetPaintingsByArtist(string artistId, [FromQuery]
        PaintigsParameters paintigsParameters)
        {
            var artist = await _repository.ArtistRepository.GetArtist(artistId, trackChanges: false);
            if(artist == null)
            {
                _logger.Info($"artist with id: {artistId} doesnt exist");
                return NotFound();
            }

            var paintigs = await _repository.PaintingRepository.GetPaintingsByAuthor(artistId, paintigsParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", 
                JsonConvert.SerializeObject(paintigs.MetaData));

            var paintingsDto = _mapper.Map<IEnumerable<PaintingDto>>(paintigs);

            return Ok(paintingsDto);
        }

        [HttpGet("{id}", Name = "GetPaintingById")]
        public async Task<IActionResult> GetPainting(string id)
        {
            var painting = await _repository.PaintingRepository.GetPaintingById(id, trackChanges: false);

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
        public async Task<IActionResult> GetPaintingInExhibition(string exhibitionId, [FromQuery]
        PaintigsParameters paintigsParameters)
        {
            var paintings = await _repository.PaintingRepository.GetPaintingsByExhibition(exhibitionId,
                paintigsParameters ,trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(paintings.MetaData));

            var paintingDto = _mapper.Map<IEnumerable<PaintingDto>>(paintings);

            return Ok(paintingDto);
        }

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePainting([FromBody] PaintingForCreationDto painting) 
        {
            var artist = await _repository.ArtistRepository.GetArtistByName(painting.ArtistId, trackChanges: false);
            if(artist == null)
            {
                return NotFound();
            }
            painting.ArtistId = artist.Id;
            var paintingEntity = _mapper.Map<Painting>(painting);
            paintingEntity.Id = Guid.NewGuid().ToString();
            _repository.PaintingRepository.CreatePainting(paintingEntity);
            await _repository.SaveAsync();

            var paintingForReturn = _mapper.Map<PaintingDto>(paintingEntity);

            return CreatedAtRoute("GetPaintingById", new {id = paintingForReturn.Id}, paintingForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeletePainting(string id)
        {
            var painting = await _repository.PaintingRepository.GetPaintingById(id, trackChanges: false);
            if(painting == null)
            {
                _logger.Info($"Paiting with id: {id} does not exist");
                return NotFound();
            }

            _repository.PaintingRepository.DeletePainting(painting);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof (ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePainting(string id, [FromBody] PaintingForUpdateDto painting)
        {
            var paintingEntity = await _repository.PaintingRepository.GetPaintingById(id, trackChanges: true);
            if(paintingEntity == null)
            {
                _logger.Info($"painting with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(painting, paintingEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
