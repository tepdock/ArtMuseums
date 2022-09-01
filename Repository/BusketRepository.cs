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
    public class BusketRepository : RepositoryBase<Busket>, IBusketRepository
    {
        public BusketRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Busket>> GetAllPurchaches(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(b => b.UserId)
            .ToListAsync();

        public async Task<IEnumerable<Busket>> GetPurchachesByUser(Guid userId, bool trackChanges) =>
            await FindByCondition(b => b.UserId.Equals(userId), trackChanges)
            .OrderBy(b => b.TourId)
            .ToListAsync();

        public async Task<Busket?> GetPurchase(Guid purchaseId, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(purchaseId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
