using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ArtistForUpdateDto : ArtistManipulationDto
    {
        public IEnumerable<PaintingForCreationDto> Paintings { get; set; }
    }
}
