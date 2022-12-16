using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPaintingRepository
    {
        Task<PagedList<Painting>> GetAllPaintings(PaintigsParameters paintigsParameters, bool trackChanges);
        Task<PagedList<Painting>> GetPaintingsByExhibition(string exhibitionId, PaintigsParameters paintigsParameters, bool trackChanges);
        Task<Painting> GetPaintingById(string paitingId, bool trackChanges);
        Task<PagedList<Painting>> GetPaintingsByAuthor(string artistId, PaintigsParameters paintigsParameters, bool trackChanges);
        void CreatePainting(Painting painting);
        void DeletePainting(Painting painting);
    }
}
