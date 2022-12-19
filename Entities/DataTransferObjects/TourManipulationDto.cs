using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract class TourManipulationDto
    {
        [Required(ErrorMessage = "Tour Places is required field")]
        [Range(5, 25, ErrorMessage = "Maximum length for the TourPlaces is 2 characters")]
        public int TourPlaces { get; set; }
    }
}
