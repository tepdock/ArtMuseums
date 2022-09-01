using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ArtistRepositoryExtension
    {
        public static IQueryable<Artist> Search(this IQueryable<Artist> artists,
            string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm))
                return artists;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return artists.Where(a => a.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
