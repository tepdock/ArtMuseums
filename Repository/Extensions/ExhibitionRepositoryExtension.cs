using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class ExhibitionRepositoryExtension
    {
        public static IQueryable<Exhibition> Search(this IQueryable<Exhibition> exhibitions,
            string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return exhibitions;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return exhibitions.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
