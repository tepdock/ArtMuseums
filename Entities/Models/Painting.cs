using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Painting
    {
        [Column("PaintingId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Painting's name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        public string Description { get; set; }

        [StringLength(4, ErrorMessage = "The Year field should be 4 characters long")]
        public int Year { get; set; }

        [ForeignKey(nameof(Artist))]
        public Guid ArtistId { get; set; }
        public Artist Artist { get; set; }

        [ForeignKey(nameof(Exhibition))]
        public Guid ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }
    }
}
