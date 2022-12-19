namespace Entities.DataTransferObjects
{
    public class PaintingForCreationDto : PaintingManipulationDto
    {
        public string Description { get; set; }
        public string ArtistId { get; set; }
    }
}
