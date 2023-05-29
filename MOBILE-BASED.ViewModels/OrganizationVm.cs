using System;
using System.Collections.Generic;
using System.Text;

namespace MOBILE_BASED.ViewModels
{
    public class OrganizationVm
    {
        public int OrganizationId { get; set; }
        public int SectorId { get; set; }
        public int CommunityId { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        public string CommunityName { get; set; }
        public string SectorName { get; set; }
        public string StateName { get; set; }
    }
}
