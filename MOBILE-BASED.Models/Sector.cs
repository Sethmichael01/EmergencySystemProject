using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string SectorCode { get; set; }
        public string SectorName { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public ICollection<EmergencyRequest> EmergencyRequests { get; set; }

    }
}
