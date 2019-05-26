using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class PropertyType
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "ערך חובה")]
        [Display(Name="סוג נכס")]
        public String Name { get; set; }

        [Required(ErrorMessage = "ערך חובה")]
        [Display(Name="סדר תצוגה")]
        public int DisplayOrder { get; set; }
    }
}
