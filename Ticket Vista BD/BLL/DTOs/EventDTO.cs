﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        [ForeignKey("Advertise")]
        public int AdvertiseId { get; set; }
        public virtual Advertise Advertise { get; set; }

        [ForeignKey("Moderator")]
        public int EmpId { get; set; }

        public virtual EmployeInfoEventDTO Moderator { get; set; }
    }
}
