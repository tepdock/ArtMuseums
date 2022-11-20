using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMuseum
{
    public interface IBasketRepository
    {
        Task<Basket> GetPurchase(Guid purchaseId, bool trackChanges);

    }
}
