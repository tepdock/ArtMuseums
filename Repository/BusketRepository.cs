using ArtMuseum;
using Entities;
using Entities.Models;
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

        public IEnumerable<Busket> GetAllPurchaches(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(b => b.UserId)
            .ToList();

        public IEnumerable<Busket> GetPurchachesByUser(Guid userId, bool trackChanges) =>
            FindByCondition(b => b.UserId.Equals(userId), trackChanges)
            .OrderBy(b => b.TourId)
            .ToList();

        public Busket GetPurchase(Guid purchaseId, bool trackChanges) =>
            FindByCondition(b => b.Id.Equals(purchaseId), trackChanges)
            .First();
    }
}
