using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PaintingForUpdateDto : PaintingManipulationDto
    {
        public string Description { get; set; }
    }
}
