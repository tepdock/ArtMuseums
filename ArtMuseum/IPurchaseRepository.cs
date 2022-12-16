using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetPurchase(string purchaseId, bool trackChanges);

    }
}
