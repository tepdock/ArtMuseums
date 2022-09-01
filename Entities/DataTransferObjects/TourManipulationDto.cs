using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class TourManipulationDto
    {
        [Required(ErrorMessage = "Tour Places is required field")]
        [Range(5, 25, ErrorMessage = "Maximum length for the TourPlaces is 2 characters")]
        public int TourPlaces { get; set; }
    }
}
