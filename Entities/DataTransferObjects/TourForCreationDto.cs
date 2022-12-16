namespace Entities.DataTransferObjects
{
    public class TourForCreationDto : TourManipulationDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}
