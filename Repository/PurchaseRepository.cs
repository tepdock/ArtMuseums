using ArtMuseum;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Purchase?> GetPurchase(string purchaseId, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(purchaseId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Purchase?>> GetPurchasesByUser(string userName,
            bool trackChanges) =>
            await FindByCondition(m => m.UserName.Equals(userName), trackChanges)
            .ToListAsync();

        public void CreatePurchase(Purchase purchase) => Create(purchase);

        public void DeletePurchase(Purchase purchase) => Delete(purchase);
    }
}
