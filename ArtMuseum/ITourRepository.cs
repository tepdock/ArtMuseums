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
        Task<PagedList<Tour>> GetAllTours(string exhibitionId, ToursParameters toursParameters, bool trackChanges);
        Task<Tour> GetTour(string tourId, bool trackChanges);
        Task<Tour> GetTourByDescr (string descr, bool trackChanges);
        void CreateTour(Tour tour);
        void DeleteTour(Tour tour);
    }
}
