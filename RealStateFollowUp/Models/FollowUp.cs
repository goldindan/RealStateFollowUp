using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models
{
    public class FollowUp
    {
        public int ID { get; set; }

        public int LeadID { get; set; }

        public int FollowUpStatusID { get; set; }

        public int FollowUpTypeID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ActionDate { get; set; }
    }
}
