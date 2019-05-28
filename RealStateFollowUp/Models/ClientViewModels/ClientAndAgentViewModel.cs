using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models.ClientViewModels
{
    public class ClientAndAgentViewModel
    {
        public Client Client { set; get; }

        public IEnumerable<Agent> AgentList { get; set; }

        //[Display(Name = "לקוח חדש")]
        //public bool IsNew { get; set; }

        public String StatusMessage { get; set; }
    }
}
