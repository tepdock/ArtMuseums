using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IBusketRepository
    {
        Task<IEnumerable<Busket>> GetAllPurchaches(bool trackChanges);
        Task<Busket> GetPurchase(Guid purchaseId, bool trackChanges);
        Task<IEnumerable<Busket>> GetPurchachesByUser(Guid userId, bool trackChanges);

    }
}
