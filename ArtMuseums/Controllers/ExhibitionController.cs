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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/exhibitions")]
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
        public async Task<IActionResult> GetExhibitions([FromQuery] ExhibitionsParameters exhibitionsParameters)
        {
            var exhibitions = await _repository.ExhibitionRepository.GetAllExhibitions(exhibitionsParameters,
                trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(exhibitions.MetaData));

            var exhibitionsDto = _mapper.Map<IEnumerable<ExhibitionDto>>(exhibitions);

            return Ok(exhibitionsDto);
        }

        [HttpGet("{id}", Name = "GetExhibitionById")]
        public async Task<IActionResult> GetExhibition( string id)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(id, trackChanges: false);
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

        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateExhibitionForMuseum([FromBody]
        ExhibitionForCreationDto exhibition)
        {
            var exhibitionEntity = _mapper.Map<Exhibition>(exhibition);

            _repository.ExhibitionRepository.CreateExhibition(exhibitionEntity);
            await _repository.SaveAsync();

            var exhibitionForReturn = _mapper.Map<ExhibitionDto>(exhibitionEntity);

            return CreatedAtRoute("GetExhibitionById", new { id = exhibitionForReturn.Id },
                exhibitionForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteExhibition( string id)
        {
            var exhibition = await _repository.ExhibitionRepository.GetExhibition(id, trackChanges: false);
            if (exhibition == null)
            {
                _logger.Info($"Exhibition with id: {id} does not exist");
                return NotFound();
            }

            _repository.ExhibitionRepository.DeleteExhibition(exhibition);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateExhibition(string id,
            [FromBody] ExhibitionForUpdateDto exhibition)
        { 
            var exhibitionEntity = await _repository.ExhibitionRepository.GetExhibition(id, trackChanges: true);
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
