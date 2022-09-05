using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ExhibitionRepositoryExtension
    {
        public static IQueryable<Exhibition> Search(this IQueryable<Exhibition> exhibitions,
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return exhibitions;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return exhibitions.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Exhibition> Sort(this IQueryable<Exhibition> exhibitions,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return exhibitions.OrderBy(a => a.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Exhibition>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return exhibitions.OrderBy(a => a.Name);

            return exhibitions.OrderBy(orderQuery);
        }
    }
}
