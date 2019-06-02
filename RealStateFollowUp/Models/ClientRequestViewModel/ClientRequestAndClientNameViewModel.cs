using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models.ClientRequestViewModel
{
    public class ClientRequestAndClientNameViewModel
    {
        public IEnumerable<ClientRequest> ClientRequests { get; set; }
        public String ClientName { get; set; }
        public int ClientID { get; set; }
    }
}
