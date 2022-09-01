using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPaintingRepository
    {
        Task<PagedList<Painting>> GetAllPaintings(PaintigsParameters paintigsParameters, bool trackChanges);
        Task<PagedList<Painting>> GetPaintingsByExhibition(Guid exhibitionId, PaintigsParameters paintigsParameters, bool trackChanges);
        Task<Painting> GetPaintingById(Guid paitingId, bool trackChanges);
        Task<PagedList<Painting>> GetPaintingsByAuthor(Guid artistId, PaintigsParameters paintigsParameters, bool trackChanges);
        void CreatePainting(Painting painting);
        void DeletePainting(Painting painting);
    }
}
