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

        public IEnumerable<Entities.Models.ArtMuseum> GetAllMuseums(bool track) =>
            FindAll(track)
            .ToList();
    }
}
