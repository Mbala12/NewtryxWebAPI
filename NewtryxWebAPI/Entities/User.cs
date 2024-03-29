﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Controlnumber { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
