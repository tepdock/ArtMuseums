using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Busket
    {
        [Column("PurchaseId")]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid TourId { get; set; }
    }
}
