using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IArtMuseumRepository
    {
        IEnumerable<Entities.Models.ArtMuseum> GetAllMuseums(bool trackChanges);
    }
}
