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

        public IEnumerable<Tour> GetAllTours(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(t => t.Tickets)
            .ToList();
    }
}
