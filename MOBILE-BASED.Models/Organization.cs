using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public int SectorId { get; set; }
        public int CommunityId { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        public Community Community { get; set; }
        public Sector Sector { get; set; }
        public ICollection<Staff> Staffs { get; set; }

    }
}
