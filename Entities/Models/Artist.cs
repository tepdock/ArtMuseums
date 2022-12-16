using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Artist
    {
        [Column("ArtistId")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Artist's name is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum Length fro the Name is 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Artist's Country is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum Length for the Country is 60 characters")]
        public string Country { get; set; }

        public ICollection<Painting> Paintings { get; set; }
    }
}
