using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class Neighborhood
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "ערך חובה")]
        [Display(Name ="שכונה")]
        public String Name { get; set; }

        [Required(ErrorMessage = "ערך חובה")]
        [Display(Name = "סדר תצוגה")]
        public int DisplayOrder { get; set; }
    }
}
