using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IRepositoryManager
    {
        ITourRepository TourRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IArtMuseumRepository ArtMuseumRepository { get; }
        IExhibitionRepository ExhibitionRepository { get; }
        IPaintingRepository PaintingRepository { get; }
        IPurchaseRepository PurchaseRepository { get; }
        Task SaveAsync();
    }
}
