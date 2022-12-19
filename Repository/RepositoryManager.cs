using ArtMuseum;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IPaintingRepository _paintingRepository;
        private IArtistRepository _artistRepository;
        private IArtMuseumRepository _artMuseumRepository;
        private ITourRepository _tourRepository;
        private IExhibitionRepository _exhibitionRepository;
        private IPurchaseRepository _purchaseRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public ITourRepository TourRepository
        {
            get
            {
                if (_tourRepository == null)
                    _tourRepository = new TourRepository(_repositoryContext);

                return _tourRepository;
            }
        }

        public IArtistRepository ArtistRepository
        {
            get
            {
                if (_artistRepository == null)
                    _artistRepository = new ArtistRepository(_repositoryContext);

                return _artistRepository;
            }
        }

        public IArtMuseumRepository ArtMuseumRepository
        {
            get
            {
                if (_artMuseumRepository == null)
                    _artMuseumRepository = new ArtMuseumRepository(_repositoryContext);

                return _artMuseumRepository;
            }
        }

        public IExhibitionRepository ExhibitionRepository
        {
            get
            {
                if (_exhibitionRepository == null)
                    _exhibitionRepository = new ExhibitionRepository(_repositoryContext);

                return _exhibitionRepository;
            }
        }

        public IPaintingRepository PaintingRepository
        {
            get
            {
                if (_paintingRepository == null)
                    _paintingRepository = new PaintingRepository(_repositoryContext);

                return _paintingRepository;
            }
        }

        public IPurchaseRepository PurchaseRepository
        {
            get
            {
                if (_purchaseRepository == null)
                    _purchaseRepository = new PurchaseRepository(_repositoryContext);

                return _purchaseRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
