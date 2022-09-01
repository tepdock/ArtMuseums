using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class MuseumForUpdateDto : MuseumManipulationDto
    {
        public IEnumerable<ExhibitionForCreationDto> Exhibitions { get; set; }
    }
}
