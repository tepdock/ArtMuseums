using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IArtMuseumRepository
    {
        Task<IEnumerable<Entities.Models.ArtMuseum>> GetAllMuseums(MuseumParameters museumParameters, bool trackChanges);
        Task<Entities.Models.ArtMuseum> GetMuseum(string museumId, bool trackChanges);
        void CreateMuseum(Entities.Models.ArtMuseum museum);
        void DeleteMuseum(Entities.Models.ArtMuseum museum);
    }
}
