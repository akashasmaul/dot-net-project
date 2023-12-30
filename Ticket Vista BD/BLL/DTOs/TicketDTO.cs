using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDTO
    {
       
        [Required]
        public int TicketQuantity { get; set; }
        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
        [Required]
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}
