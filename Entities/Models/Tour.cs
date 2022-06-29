using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tour
    {
        [Column("TourId")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Maximum length for the TourPlaces is 2 characters")]
        public int TourPlaces { get; set; }

        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        [ForeignKey(nameof(Exhibition))]
        public Guid ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
