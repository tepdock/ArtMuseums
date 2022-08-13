using ArtMuseum;
using Entities;
using Entities.Models;
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

        public IEnumerable<User> GetAllUsers(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(u => u.Login)
            .ToList();

        public User GetUser(Guid id, bool trackChanges) =>
            FindByCondition(u => u.Id.Equals(id), trackChanges)
            .First();

        public User GetUserByLogin(string login, bool trackChanges) =>
            FindByCondition(u => u.Login.Equals(login), trackChanges)
            .First();

        public User GetUserByPassword(string password, bool trackChanges) =>
            FindByCondition(u => u.Password.Equals(password), trackChanges)
            .First();
    }
}
