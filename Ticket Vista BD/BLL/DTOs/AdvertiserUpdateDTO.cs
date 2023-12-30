﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdvertiserUpdateDTO
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
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
        [StringLength(11, MinimumLength = 7)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string Nationality { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(20)]
        public string City { get; set; }
    }
}
