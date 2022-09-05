using Entities.Models;
using Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class TourRepositoryExtension
    {
        public static IQueryable<Tour> FilterTour(this IQueryable<Tour> tours,
            uint minPlaces, uint maxPlaces) =>
            tours.Where(tour => (tour.TourPlaces >= minPlaces && tour.TourPlaces <= maxPlaces));

        public static IQueryable<Tour> Search(this IQueryable<Tour> tours, 
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return tours;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return tours.Where(tour => tour.TourPlaces.ToString().Contains(lowerCaseTerm));
        }

        public static IQueryable<Tour> Sort(this IQueryable<Tour> tours,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return tours.OrderBy(t => t.TourPlaces);

            var queryOrder = OrderQueryBuilder.CreateOrderQuery<Tour>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(queryOrder))
                return tours.OrderBy(t => t.TourPlaces);

            return tours.OrderBy(queryOrder);
        }
    }
}
