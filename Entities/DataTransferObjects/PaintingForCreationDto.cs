using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PaintingForCreationDto : PaintingManipulationDto
    {
        public string Description { get; set; }
        public string ArtistId { get; set; }
    }
}
