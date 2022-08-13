using ArtMuseum;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        public TicketRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Ticket GetTicketById(Guid ticketId, bool trackChanges) =>
            FindByCondition(t => t.Id.Equals(ticketId), trackChanges)
            .First();

        public IEnumerable<Ticket> GetAllTickets(Guid TourId, bool trackChanges) =>
            FindByCondition(t => t.TourId.Equals(TourId), trackChanges)
            .OrderBy(t => t.TicketCost)
            .ToList();

        public IEnumerable<Ticket> GetTicketsByUser(Guid UserId, bool trackChanges)=>
            FindByCondition(t => t.UserId.Equals(UserId), trackChanges)
            .OrderBy(t => t.TicketCost)
            .ToList();

        public void CreateTicket(Ticket ticket) => Create(ticket);

        public void DeleteTicket(Ticket ticket) => Delete(ticket);
    }
}
