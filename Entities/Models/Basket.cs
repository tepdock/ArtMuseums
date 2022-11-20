using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Basket
    {
        [Column("PurchaseId")]
        public Guid Id { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
