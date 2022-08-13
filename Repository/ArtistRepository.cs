using ArtMuseum;
using Entities;
using Entities.Models;
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

        public IEnumerable<Artist> GetAllArtists(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(a=>a.Name)
            .ToList();

        public IEnumerable<Artist> GetAllArtistsByCountry(string country, bool trackChanges) =>
            FindByCondition(a => a.Country.Equals(country), trackChanges)
            .OrderBy(a => a.Name)
            .ToList();

        public Artist GetArtistByName(string artistName, bool trackChanges) =>
            FindByCondition(a => a.Name.Equals(artistName), trackChanges)
            .SingleOrDefault();

        public Artist GetArtist(Guid artisId, bool trackChanges)=>
            FindByCondition(a => a.Id.Equals(artisId), trackChanges)
            .SingleOrDefault();

        public void CreateArtist(Artist artist) => Create(artist);

        public void DeleteArtist(Artist artist) => Delete(artist);
    }
}
