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

        public async Task<PagedList<Purchase>> GetPurchasesByUser(string userid, PurchaseParameters purchaseParameters,
            bool trackChanges)
        {
            var purchases = await FindByCondition(p => p.UserId.Equals(userid), trackChanges)
                .ToListAsync();

            return PagedList<Purchase>.ToPagedList(purchases, purchaseParameters.PageNumber, purchaseParameters.PageSize);
        }

        public void CreatePurchase(Purchase purchase) => Create(purchase);

        public void DeletePurchase(Purchase purchase) => Delete(purchase);
    }
}
