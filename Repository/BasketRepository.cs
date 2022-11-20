using ArtMuseum;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BasketRepository : RepositoryBase<Basket>, IBasketRepository
    {
        public BasketRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Basket?> GetPurchase(Guid purchaseId, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(purchaseId), trackChanges)
            .SingleOrDefaultAsync();

        //public async Task<PagedList<Basket>> GetPurchasesByUser(Guid userid, bool trackChanges)
        //{

        //}

        public void CreatePurchase(Basket basket) => Create(basket);

        public void DeletePurchase(Basket basket) => Delete(basket);
    }
}
