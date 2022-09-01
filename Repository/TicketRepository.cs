using ArtMuseum;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Ticket?> GetTicketById(Guid ticketId, bool trackChanges) =>
            await FindByCondition(t => t.Id.Equals(ticketId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Ticket>> GetAllTickets(Guid TourId, bool trackChanges) =>
            await FindByCondition(t => t.TourId.Equals(TourId), trackChanges)
            .OrderBy(t => t.TicketCost)
            .ToListAsync();

        public async Task<IEnumerable<Ticket>> GetTicketsByUser(Guid UserId, bool trackChanges)=>
            await FindByCondition(t => t.UserId.Equals(UserId), trackChanges)
            .OrderBy(t => t.TicketCost)
            .ToListAsync();

        public void CreateTicket(Ticket ticket) => Create(ticket);

        public void DeleteTicket(Ticket ticket) => Delete(ticket);
    }
}
