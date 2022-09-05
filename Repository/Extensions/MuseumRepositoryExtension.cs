using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public static IQueryable<Entities.Models.ArtMuseum> Sort(this IQueryable<Entities.Models.ArtMuseum> museums,
            string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return museums.OrderBy(m => m.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Entities.Models.ArtMuseum>(orderByQueryString);

            if(string.IsNullOrWhiteSpace(orderQuery))
                return museums.OrderBy(m => m.Name);

            return museums.OrderBy(orderQuery);
        }
    }
}
