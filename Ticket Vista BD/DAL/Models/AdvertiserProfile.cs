﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class AdvertiserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string Nationality { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }

        [ForeignKey("Advertise")]
        public int AdvertiseId { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }
        public virtual Advertise Advertise { get; set; }
        public virtual User User { get; set; }
    }
}
