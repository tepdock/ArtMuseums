using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class MuseumRepositoryExtension
    {
        public static IQueryable<Entities.Models.ArtMuseum> Search(this IQueryable<Entities.Models.ArtMuseum> museums,
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return museums;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return museums.Where(m => m.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
