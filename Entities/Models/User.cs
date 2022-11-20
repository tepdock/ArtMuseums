using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class User : IdentityUser
    {
        [Column("UserId")]
        public new Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey(nameof(Basket))]
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
