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
        Task<IEnumerable<Ticket>> GetAllTickets(string TourId, bool trackChanges);
        Task<Ticket> GetTicketById(string ticketId, bool trackChanges);
        void CreateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
