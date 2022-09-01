using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IExhibitionRepository
    {
        Task<PagedList<Exhibition>> GetAllExhibitions(Guid museumId, ExhibitionsParameters exhibitionsParameters,
            bool trackChanges);
        Task<Exhibition> GetExhibition(Guid museumId, Guid exhibitionId, bool trackChanges);
        void CreateExhibition(Guid museumId, Exhibition exhibition);
        void DeleteExhibition(Guid museumId, Exhibition exhibition);
    }
}
