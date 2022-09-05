using System;
using ArtMuseum;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Entities.RequestFeatures;
using Repository.Extensions;

namespace Repository
{
    public class ExhibitionRepository : RepositoryBase<Exhibition>, IExhibitionRepository
    {
        public ExhibitionRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<Exhibition?> GetExhibition(Guid museumId, Guid exhibitionId, bool trackChanges) =>
            await FindByCondition(e => e.Id.Equals(exhibitionId) && e.ArtMuseumId.Equals(museumId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Exhibition>> GetAllExhibitions(Guid museumId, ExhibitionsParameters exhibitionsParameters,
            bool trackChanges)
        {
            var exhibitions = await FindAll(trackChanges)
                .Search(exhibitionsParameters.SearchTerm)
                .Sort(exhibitionsParameters.OrderBy)
                .ToListAsync();

            return PagedList<Exhibition>
                .ToPagedList(exhibitions, exhibitionsParameters.PageNumber, exhibitionsParameters.PageSize);
        }

        public void CreateExhibition(Guid museumId, Exhibition exhibition) 
        {
            exhibition.ArtMuseumId = museumId;
            Create(exhibition);
        }

        public void DeleteExhibition(Guid museumId, Exhibition exhibition)
        {
            exhibition.ArtMuseumId = museumId;
            Delete(exhibition);
        }
    }
}
