using ArtMuseum;
using AutoMapper;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ArtMuseums.Controllers
{
    [Route("api/tours")]
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
        public IActionResult GetTours(Guid exhibitionId)
        {
            //var exhibition = _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            //if(exhibition == null)
            //{
            //    _logger.Info($"exhibition with id: {exhibitionId} doesn't exist");
            //    return NotFound();
            //}

            var tours = _repository.TourRepository.GetAllTours(exhibitionId, trackChanges: false);

            var toursDto = _mapper.Map<IEnumerable<TourDto>>(tours);

            return Ok(toursDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetTour(Guid exhibitionId, Guid tourId)
        {
            //var exhibition = _repository.ExhibitionRepository.GetExhibition(exhibitionId, trackChanges: false);
            //if(exhibition == null)
            //{
            //    _logger.Info($"exhibition with id: {exhibitionId} doesnt exist");
            //    return NotFound();
            //}

            var tour = _repository.TourRepository.GetTour(tourId, trackChanges: false);
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

    }
}
