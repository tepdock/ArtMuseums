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
        public IActionResult GetTickets(Guid tourId)
        {
            var tour = _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if (tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesn't exist");
                return NotFound();
            }

            var tickets = _repository.TicketRepository.GetAllTickets(tourId, trackChanges: false);

            var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);

            return Ok(ticketsDto);
        }

        [HttpGet("{id}", Name = "GetTicketById")]
        public IActionResult GetTicket(Guid ticketId, Guid tourId)
        {
            var tour = _repository.TourRepository.GetTour(tourId, trackChanges: false);
            if(tour == null)
            {
                _logger.Info($"tour with id: {tourId} doesnt exist");
                return NotFound();
            }

            var ticket = _repository.TicketRepository.GetTicketById(ticketId, trackChanges: false);
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

        [HttpGet("user/{userId}")]
        public IActionResult GetUsersTickets(Guid userId)
        {
            var user = _repository.UserRepository.GetUser(userId, trackChanges: false);
            if(user == null)
            {
                _logger.Info($"user with id: {userId} doesn't exist");
                return NotFound();
            }

            var userTickets = _repository.TicketRepository.GetTicketsByUser(userId, trackChanges: false);

            var userTicketsDto = _mapper.Map<IEnumerable<TicketDto>>(userTickets);

            return Ok(userTicketsDto);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] TicketForCreationDto ticket)
        {
            if(ticket == null)
            {
                _logger.Error("TicketForCreationDto object sent by client is null");
                return BadRequest("TicketForCreationDto object is null");
            }

            var ticketEntity = _mapper.Map<Ticket>(ticket);

            _repository.TicketRepository.CreateTicket(ticketEntity);
            _repository.Save();

            var ticketForReturn = _mapper.Map<TicketDto>(ticketEntity);

            return CreatedAtRoute("GetTicketById", new { id = ticketForReturn.Id }, ticketForReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(Guid id)
        {
            var ticket = _repository.TicketRepository.GetTicketById(id, trackChanges: false);
            if(ticket == null)
            {
                _logger.Info($"ticket with id: {id} doesn't exist");
                return NotFound();
            }

            _repository.TicketRepository.DeleteTicket(ticket);
            _repository.Save();

            return NoContent();
        }
    }
}
