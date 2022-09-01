using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class TicketManipulationDto
    {
        [Required(ErrorMessage = "The ticket cost is a required field.")]
        [Range(10, 200, ErrorMessage = "Ticket cost must be min = 10 or max = 200")]
        public int TicketCost { get; set; }
    }
}
