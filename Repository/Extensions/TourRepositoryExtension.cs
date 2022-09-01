using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
