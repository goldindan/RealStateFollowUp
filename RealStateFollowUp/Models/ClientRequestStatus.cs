using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class ClientRequestStatus
    {
        public int ID { get; set; }

        [Display(Name = "סטטוס")]
        public String Name { get; set; }

    }
}
