using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Purchase
    {
        [Column("PurchaseId")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Ticket))]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
