using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface ITourRepository
    {
        IEnumerable<Tour> GetAllTours(Guid exhibitionId, bool trackChanges);
        Tour GetTour(Guid tourId, bool trackChanges);
    }
}
