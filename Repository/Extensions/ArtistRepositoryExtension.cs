using Entities.Models;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Repository.Extensions.Utility;

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

        public static IQueryable<Artist> Sort(this IQueryable<Artist> artists,
            string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return artists.OrderBy(a => a.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Artist>(orderByQueryString);

            if(string.IsNullOrWhiteSpace(orderQuery))
                return artists.OrderBy(a => a.Name);

            return artists.OrderBy(orderQuery);
        }
    }
}
