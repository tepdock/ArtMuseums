using ArtMuseum;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArtistRepository : RepositoryBase<Artist>, IArtistRepository
    {
        public ArtistRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
           
        }

        public async Task<PagedList<Artist>> GetAllArtists(ArtistsParameters artistsParameters, bool trackChanges)
        {
            var artists = await FindAll(trackChanges)
                .Search(artistsParameters.SearchTerm)
                .Sort(artistsParameters.OrderBy)
                .ToListAsync();

            return PagedList<Artist>
                .ToPagedList(artists, artistsParameters.PageNumber, artistsParameters.PageSize);
        }

        public async Task<Artist?> GetArtist(Guid artisId, bool trackChanges)=>
            await FindByCondition(a => a.Id.Equals(artisId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateArtist(Artist artist) => Create(artist);

        public void DeleteArtist(Artist artist) => Delete(artist);
    }
}
