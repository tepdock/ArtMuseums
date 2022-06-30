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

        public IEnumerable<Artist> GetAllArtists(bool track)=>
            FindAll(track)
            .OrderBy(a=>a.Name)
            .ToList();
    }
}
