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
        public string Id { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "Maximum length for the TourPlaces is 2 characters")]
        public int TourPlaces { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Exhibition))]
        public string ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
