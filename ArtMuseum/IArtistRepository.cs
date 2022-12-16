using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IArtistRepository
    {
        Task<PagedList<Artist>> GetAllArtists(ArtistsParameters artistsParameters, bool trackChanges);
        Task<Artist> GetArtist(string artisId, bool trackChanges);
        Task<Artist> GetArtistByName(string name, bool trackChanges);
        void CreateArtist (Artist artist);
        void DeleteArtist (Artist artist);
    }
}
