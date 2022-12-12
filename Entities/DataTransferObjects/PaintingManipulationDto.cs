using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract class PaintingManipulationDto
    {
        [Required(ErrorMessage = "The Painting's name is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Picture is required")]
        public string Picture { get; set; }

        [StringLength(4, ErrorMessage = "The Year field should be 4 characters long")]
        public int Year { get; set; }

        public string Category { get; set; }
    }
}
