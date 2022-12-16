using ArtMuseum;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;

namespace Repository
{
    public class PaintingRepository : RepositoryBase<Painting>, IPaintingRepository
    {
        public PaintingRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Painting>> GetPaintingsByAuthor(string artistId, PaintigsParameters paintigsParameters, bool trackChanges)
        {
            var paintigs = await FindByCondition(p => p.Artist.Equals(artistId), trackChanges)
                .Sort(paintigsParameters.OrderBy)
                .ToListAsync();

            return PagedList<Painting>
                .ToPagedList(paintigs, paintigsParameters.PageNumber, paintigsParameters.PageSize);
        }

        public async Task<PagedList<Painting>> GetPaintingsByExhibition(string exhibitionId, PaintigsParameters paintigsParameters,
            bool trackChanges)
        {
            var paintigs = await FindByCondition(p => p.ExhibitionId.Equals(exhibitionId), trackChanges)
                .Sort(paintigsParameters.OrderBy)
                .ToListAsync();

            return PagedList<Painting>
                .ToPagedList(paintigs, paintigsParameters.PageNumber, paintigsParameters.PageSize);
        }

        public async Task<Painting?> GetPaintingById(string paitingId, bool trackChanges) =>
            await FindByCondition(p => p.Id.Equals(paitingId), trackChanges)
            .Include(p => p.Artist)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Painting>> GetAllPaintings(PaintigsParameters paintigsParameters, bool trackChanges)
        {
            var paintigs = await FindAll(trackChanges)
                .FilterPaintigs(paintigsParameters.Category)
                .Search(paintigsParameters.SearchTerm)
                .Sort(paintigsParameters.OrderBy)
                .Include(p => p.Artist)
                .ToListAsync();

            return PagedList<Painting>
                .ToPagedList(paintigs, paintigsParameters.PageNumber, paintigsParameters.PageSize);
        }

        public void CreatePainting(Painting painting) => Create(painting);

        public void DeletePainting(Painting painting) => Delete(painting);
    }
}
