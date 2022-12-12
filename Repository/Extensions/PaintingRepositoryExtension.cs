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
    public static class PaintingRepositoryExtension
    {
        public static IQueryable<Painting> FilterPaintigs(this IQueryable<Painting> paintings,
            string category, uint minYear, uint maxYear) 
        {
            if (category == null)
            {
                return paintings.Where(p => (p.Year >= minYear && p.Year <= maxYear));
            }
            else return paintings.Where(p => p.Category.Equals(category));
        }
            
        
        public static IQueryable<Painting> Search(this IQueryable<Painting> paintings,
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return paintings;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return paintings.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Painting> Sort(this IQueryable<Painting> paintings,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return paintings.OrderBy(a => a.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Painting>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return paintings.OrderBy(a => a.Name);

            return paintings.OrderBy(orderQuery);
        }
    }
}
