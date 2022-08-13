using System;
using ArtMuseum;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

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

        public IEnumerable<Entities.Models.ArtMuseum> GetAllMuseums(bool trackChanges) =>
            FindAll(trackChanges)
            .ToList();

        public Entities.Models.ArtMuseum GetMuseum(Guid museumId, bool trackChanges) =>
            FindByCondition(m => m.Id.Equals(museumId), trackChanges)
            .SingleOrDefault();

        public Entities.Models.ArtMuseum GetMuseumByName(string name, bool trackChanges) =>
            FindByCondition(m => m.Name.Equals(name), trackChanges)
            .SingleOrDefault();

    }
}
