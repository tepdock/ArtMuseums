using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface ITicketRepository
    {
        IEnumerable<Entities.Models.Ticket> GetAllTickets(bool trackChanges);
    }
}
