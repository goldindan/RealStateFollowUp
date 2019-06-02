using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class Lead
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int LeadTypeID { get; set; }

        public int LeadStatusID { get; set; }

        public int NeighborhhodID { get; set; }

        public String Address { get; set; }

        public String ContactName { get; set; }

        public String ContactPhone { get; set; }

        public bool IsContactAnAgent { get; set; }

        public String Notes { get; set; }
    }
}
