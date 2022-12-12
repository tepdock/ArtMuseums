using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Ticket
    {
        [Column("TicketId")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(3)]
        public int TicketCost { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        [ForeignKey(nameof(Tour))]
        public Guid TourId { get; set; }
        public Tour Tour { get; set; }
    }
}
