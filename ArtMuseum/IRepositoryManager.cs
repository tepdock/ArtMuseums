using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IRepositoryManager
    {
        ITourRepository TourRepository { get; }
        ITicketRepository TicketRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IArtMuseumRepository ArtMuseumRepository { get; }
        IExhibitionRepository ExhibitionRepository { get; }
        IPaintingRepository PaintingRepository { get; }
        IPurchaseRepository BusketRepository { get; }
        Task SaveAsync();
    }
}
