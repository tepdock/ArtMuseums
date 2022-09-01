using ArtMuseum;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)=>
            await FindAll(trackChanges)
            .OrderBy(u => u.Login)
            .ToListAsync();

        public async Task<User?> GetUser(Guid id, bool trackChanges) =>
            await FindByCondition(u => u.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<User?> GetUserByLogin(string login, bool trackChanges) =>
            await FindByCondition(u => u.Login.Equals(login), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<User?> GetUserByPassword(string password, bool trackChanges) =>
            await FindByCondition(u => u.Password.Equals(password), trackChanges)
            .SingleOrDefaultAsync();
    }
}
