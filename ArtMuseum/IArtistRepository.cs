using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAllArtists(bool trackChanges);
        Artist GetArtist(Guid artisId, bool trackChanges);
        Artist GetArtistByName(string artistName, bool trackChanges);
        IEnumerable<Artist> GetAllArtistsByCountry(string country, bool trackChanges);
        void CreateArtist (Artist artist);
        void DeleteArtist (Artist artist);
    }
}
