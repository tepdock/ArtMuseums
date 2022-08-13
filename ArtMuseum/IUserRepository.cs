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
        IEnumerable<User> GetAllUsers(bool trackChanges);
        User GetUser(Guid id, bool trackChanges);
        User GetUserByLogin(string login, bool trackChanges);
        User GetUserByPassword(string password, bool trackChanges);
    }
}
