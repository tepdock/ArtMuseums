using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ExhibitionForCreationDto : ExhibitionManipulationDto
    {
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
