﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class Agent
    {
        [Required]
        public int ID { get; set; }

        [Display(Name ="שם פרטי")]
        public String FirstName { get; set; }

        [Display(Name ="שם משפחה")]
        public String  LastName { get; set; }

        [Display(Name ="תעודת זהות")]
        public int IdentityCard { get; set; }

        [Display(Name = "דוא\"ל")]
        public String Email { get; set; }

        [Display(Name ="מספר טלפון")]
        public String Phone { get; set; }

        [Display(Name = "שם הסוכן")]
        public String Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
