using ArtMuseum;
using ArtMuseums.ActionFilters;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtMuseums.Controllers
{
    [Route("api/tours/{tourId}/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public TicketController(IRepositoryManager repository, ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets(string tourId)
        {
            var tour = await _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if (tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesn't exist");
                return NotFound();
            }

            var tickets = await _repository.TicketRepository.GetAllTickets(tourId, trackChanges: false);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return Ok(ticketsDto);
        }

        [HttpGet("{id}", Name = "GetTicketById")]
        public async Task<IActionResult> GetTicket(string ticketId, string tourId)
        {
            var tour = await _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if(tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesnt exist");
                return NotFound();
            }

            var ticket = await _repository.TicketRepository.GetTicketById(ticketId, trackChanges: false);
            if(ticket == null)
            {
                _logger.Info($"ticket with id: {ticketId} doesn't exist");
                return NotFound();
            }
            else
            {
                var ticketDto = _mapper.Map<TicketDto>(ticket);
                return Ok(ticketDto);
            }
        }


        [HttpPost, Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTicket([FromBody] TicketForCreationDto ticket)
        {
            var ticketEntity = _mapper.Map<Ticket>(ticket);

            _repository.TicketRepository.CreateTicket(ticketEntity);
            await _repository.SaveAsync();

            var ticketForReturn = _mapper.Map<TicketDto>(ticketEntity);

            return CreatedAtRoute("GetTicketById", new { id = ticketForReturn.Id }, ticketForReturn);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            var ticket = await _repository.TicketRepository.GetTicketById(id, trackChanges: false);
            if(ticket == null)
            {
                _logger.Info($"ticket with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.TicketRepository.DeleteTicket(ticket);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}"), Authorize(Roles = "Administrator")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTicket(string tourId, string id, 
            [FromBody] TicketForUpdatingDto ticket)
        {
            var tour = await _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if(tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesn't exist");
                return NotFound();
            }

            var ticketEntity = await _repository.TicketRepository.GetTicketById(id, trackChanges: true);
            if(ticketEntity == null)
            {
                _logger.Info($"ticket with id: {id} doesn't exist");
                return NotFound();
            }

            _mapper.Map(ticket, ticketEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
