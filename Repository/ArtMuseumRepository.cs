using System;
using ArtMuseum;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Entities.RequestFeatures;

namespace Repository
{
    public class ArtMuseumRepository : RepositoryBase<Entities.Models.ArtMuseum>,
        IArtMuseumRepository
    {
        public ArtMuseumRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void CreateMuseum(Entities.Models.ArtMuseum museum) => Create(museum);

        public void DeleteMuseum(Entities.Models.ArtMuseum museum) => Delete(museum);

        public async Task<IEnumerable<Entities.Models.ArtMuseum>> GetAllMuseums(MuseumParameters museumParameters,
            bool trackChanges) =>
            await FindAll(trackChanges)
            .Search(museumParameters.SearchTerm)
            .Sort(museumParameters.OrderBy)
            .ToListAsync();

        public async Task<Entities.Models.ArtMuseum?> GetMuseum(Guid museumId, bool trackChanges) =>
            await FindByCondition(m => m.Id.Equals(museumId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
