using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class PaintingRepositoryExtension
    {
        public static IQueryable<Painting> FilterPaintigs(this IQueryable<Painting> paintings,
            uint minYear, uint maxYear) =>
            paintings.Where(p => (p.Year >= minYear && p.Year <= maxYear));

        public static IQueryable<Painting> Search(this IQueryable<Painting> paintings,
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return paintings;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return paintings.Where(p => p.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
