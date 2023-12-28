using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AdvertiserAdvertise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Advertiser")]
        public int AdvertiserId { get; set; }
        public virtual Advertiser Advertiser { get; set; }
        [Required]
        [ForeignKey("Advertise")]
        public int AdvertiseId { get; set; }
        public virtual Advertise Advertise { get; set; }
    }
}
