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
        IEnumerable<Busket> GetAllPurchaches(bool trackChanges);
        Busket GetPurchase(Guid purchaseId, bool trackChanges);
        IEnumerable<Busket> GetPurchachesByUser(Guid userId, bool trackChanges);

    }
}
