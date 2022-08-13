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
    internal class TourRepository : RepositoryBase<Tour>, ITourRepository
    {
        public TourRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Tour GetTour(Guid tourId, bool trackChanges)=>
            FindByCondition(t => t.Id.Equals(tourId), trackChanges)
            .First();

        public IEnumerable<Tour> GetAllTours(Guid exhibitionId, bool trackChanges) =>
            FindByCondition(t => t.ExhibitionId.Equals(exhibitionId), trackChanges)
            .OrderByDescending(t => t.ExhibitionId)
            .ToList();
    }
}
