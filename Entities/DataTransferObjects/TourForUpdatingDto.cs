using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TourForUpdatingDto : TourManipulationDto
    {
        public string Description { get; set; }

        public IEnumerable<TicketForCreationDto> Tickets { get; set; }
    }
}
