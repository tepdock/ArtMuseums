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
    public class PaintingRepository : RepositoryBase<Painting>, IPaintingRepository
    {
        public PaintingRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<Painting> GetPaintingsByAuthor(Guid artistId, bool trackChanges)=>
            FindByCondition(p => p.ArtistId.Equals(artistId), trackChanges)
            .OrderBy(p => p.Name)
            .ToList();

        public IEnumerable<Painting> GetPaintingsByExhibition(Guid exhibitionId,
            bool trackChanges) =>
            FindByCondition(p => p.ExhibitionId.Equals(exhibitionId), trackChanges)
            .OrderBy(p => p.Name)
            .ToList();

        public Painting GetPaintingById(Guid paitingId, bool trackChanges) =>
            FindByCondition(p => p.Id.Equals(paitingId), trackChanges)
            .Single();

        public IEnumerable<Painting> GetPaintingsByName(string name, bool trackChanges) =>
            FindByCondition(p => p.Name.Equals(name), trackChanges)
            .OrderBy(p => p.Year)
            .ToList();

        public IEnumerable<Painting> GetAllPaintings(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(p => p.Name)
            .ToList();

        public void CreatePainting(Painting painting) => Create(painting);

        public void DeletePainting(Painting painting) => Delete(painting);
    }
}
