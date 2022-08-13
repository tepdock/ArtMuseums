using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IExhibitionRepository
    {
        IEnumerable<Exhibition> GetAllExhibitions(Guid museumId, bool trackChanges);
        Exhibition GetExhibition(Guid museumId, Guid exhibitionId, bool trackChanges);
        void CreateExhibition(Guid museumId, Exhibition exhibition);
        void DeleteExhibition(Guid museumId, Exhibition exhibition);
    }
}
