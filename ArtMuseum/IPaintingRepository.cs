using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IPaintingRepository
    {
        IEnumerable<Entities.Models.Painting> GetAllPaintings(bool trackChanges);
    }
}
