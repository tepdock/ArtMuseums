using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TourDto
    {
        public Guid Id { get; set; }
        public int TourPlaces { get; set; }
        public string Description { get; set; }
    }
}
