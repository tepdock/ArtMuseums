using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        Task<User> GetUser(Guid id, bool trackChanges);
        Task<User> GetUserByLogin(string login, bool trackChanges);
        Task<User> GetUserByPassword(string password, bool trackChanges);
    }
}
