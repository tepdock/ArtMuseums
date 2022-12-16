using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Exhibition
    {
        [Column("ExpositionId")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Exposition name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
        public string Name { get; set; }

        public string Picture { get; set; }
        public string Description { get; set; }

        public ICollection<Painting> Paintigs { get; set; }

        public ICollection<Tour> Tours { get; set; }

        [ForeignKey(nameof(ArtMuseum))]
        public string ArtMuseumId { get; set; }
        public ArtMuseum ArtMuseum { get; set; }
    }
}
