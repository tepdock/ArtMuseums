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
    public class ExhibitionRepository : RepositoryBase<Exhibition>, IExhibitionRepository
    {
        public ExhibitionRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Exhibition GetExhibition(Guid museumId, Guid exhibitionId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(exhibitionId) && e.ArtMuseumId.Equals(museumId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Exhibition> GetAllExhibitions(Guid museumId, bool trackChanges) =>
            FindByCondition(e => e.ArtMuseumId.Equals(museumId), trackChanges)
            .OrderBy(e => e.Name)
            .ToList();

        public void CreateExhibition(Guid museumId, Exhibition exhibition) 
        {
            exhibition.ArtMuseumId = museumId;
            Create(exhibition);
        }

        public void DeleteExhibition(Guid museumId, Exhibition exhibition)
        {
            exhibition.ArtMuseumId = museumId;
            Delete(exhibition);
        }
    }
}
