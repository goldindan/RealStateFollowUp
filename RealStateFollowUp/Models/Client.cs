using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class Client
    {
        [Required]
        public int ID { get; set; }

        [Display(Name = "שם משפחה")]
        public String LastName { get; set; }

        [Display(Name ="שם פרטי")]
        public String FirstName { get; set; }

        [Display(Name ="תעודת זהות")]
        public int? IdentityCard { get; set; }

        [Display(Name ="דוא\"ל")]
        public String Email { get; set; }

        [Display(Name ="עיר")]
        public String City { get; set; }

        [Display(Name = "רחוב")]
        public String Street { get; set; }

        [Display(Name = "מספר בית")]
        public String StreetNum { get; set; }

        [Display(Name = "מספר דירה")]
        public String Appartment { get; set; }

        [Display(Name ="הארות")]
        public String Notes { get; set; }

        [Display(Name = "מספר טלפון")]
        public String PhoneNumber { get; set; }

        public int? AgentID { get; set; }

    }
}
