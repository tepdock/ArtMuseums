using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class MuseumManipulationDto
    {
        [Required(ErrorMessage = "Museum's Adress is a required field")]
        [MaxLength(100, ErrorMessage = "Max Length for the Adress is 100 characters")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Museum's Name is a required field")]
        [MaxLength(100, ErrorMessage = "Max Length for the Name is 100 characters")]
        public string Name { get; set; }
    }
}
