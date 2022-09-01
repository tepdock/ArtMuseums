using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface ITourRepository
    {
        Task<PagedList<Tour>> GetAllTours(Guid exhibitionId, ToursParameters toursParameters, bool trackChanges);
        Task<Tour> GetTour(Guid tourId, bool trackChanges);
        void CreateTour(Tour tour);
        void DeleteTour(Tour tour);
    }
}
