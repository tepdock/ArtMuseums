using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IExhibitionRepository
    {
        IEnumerable<Entities.Models.Exhibition> GetAllExhibitions(bool trackChanges);
    }
}
