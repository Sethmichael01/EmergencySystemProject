using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class Community
    {
        public int CommunityId { get; set; }
        public int LocalGovernmentId { get; set; }
        public string ZipCode { get; set; }
        public string CommunityName { get; set; }
        public LocalGovernment LocalGovernment { get; set; }
        public ICollection<Organization> Organizations { get; set; }
    }
}
