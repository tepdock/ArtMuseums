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
        Task<PagedList<Exhibition>> GetAllExhibitions(ExhibitionsParameters exhibitionsParameters,
            bool trackChanges);
        Task<Exhibition> GetExhibition(string exhibitionId, bool trackChanges);
        void CreateExhibition(Exhibition exhibition);
        void DeleteExhibition(Exhibition exhibition);
    }
}
