using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IUserRepository
    {
        IEnumerable<Entities.Models.User> GetAllUsers(bool trackChanges);
    }
}
