using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface ITourRepository
    {
        IEnumerable<Entities.Models.Tour> GetAllTours(bool trackChanges);
    }
}
