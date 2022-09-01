using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ExhibitionForUpdateDto : ExhibitionManipulationDto
    {
        public string Description { get; set; }
        public string Picture { get; set; }

        public IEnumerable<TourForCreationDto> Tours { get; set; }
    }
}
