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
        Entities.Models.ArtMuseum GetMuseum(Guid museumId, bool trackChanges);
        Entities.Models.ArtMuseum GetMuseumByName(string name, bool trackChanges);
        void CreateMuseum(Entities.Models.ArtMuseum museum);
        void DeleteMuseum(Entities.Models.ArtMuseum museum);
    }
}
