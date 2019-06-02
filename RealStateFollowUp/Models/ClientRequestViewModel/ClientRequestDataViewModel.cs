using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Models.ClientRequestViewModel
{
    public class ClientRequestDataViewModel
    {
        public ClientRequest ClientRequest { get; set; }
        public String ClientName { get; set; }
        public List<ClientRequestStatus> ClientRequestStatuses { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }
        public List<PropertyType> PropertyTypes { get; set; }
        public List<MainDirection> MainDirections { get; set; }
        public List<MasterBedroom> MasterBedrooms { get; set; }

        public String StatusMessage { get; set; }

    }
}
