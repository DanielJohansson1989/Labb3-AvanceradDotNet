﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        [Required]
        public string URL { get; set; }

        public int PersonalInterestId { get; set; }
        public PersonalInterest PersonalInterest { get; set; }

    }
}
