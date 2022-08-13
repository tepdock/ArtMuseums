using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPaintingRepository
    {
        IEnumerable<Painting> GetAllPaintings(bool trackChanges);
        public IEnumerable<Painting> GetPaintingsByExhibition(Guid exhibitionId, bool trackChanges);
        public Painting GetPaintingById(Guid paitingId, bool trackChanges);
        public IEnumerable<Painting> GetPaintingsByName(string name, bool trackChanges);
        public IEnumerable<Painting> GetPaintingsByAuthor(Guid artistId, bool trackChanges);
        void CreatePainting(Painting painting);
        void DeletePainting(Painting painting);
    }
}
