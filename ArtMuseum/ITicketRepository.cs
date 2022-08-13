using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets(Guid TourId, bool trackChanges);
        IEnumerable<Ticket> GetTicketsByUser(Guid UserId, bool trackChanges);
        Ticket GetTicketById(Guid ticketId, bool trackChanges);
        void CreateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
