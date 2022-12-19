using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetPurchase(string purchaseId, bool trackChanges);
        Task<IEnumerable<Purchase?>> GetPurchasesByUser(string userName,
            bool trackChanges);
        void CreatePurchase(Purchase purchase);
        void DeletePurchase(Purchase purchase);
    }
}
