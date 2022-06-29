using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The length of the Login should not be at least 5 characters"), 
         MaxLength(20, ErrorMessage = "The length of the Login should not be more than 20 characters")]
        public string Login { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The length of the Password should not be at least 8 characters"),
         MaxLength(32, ErrorMessage = "The length of the Password should not be more than 32 characters")]
        public string Password { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
