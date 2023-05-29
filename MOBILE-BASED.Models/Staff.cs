using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class Staff : Person
    {
        public int StaffId { get; set; }
        public int OrganizationId { get; set; }
        public string StaffNumber { get; set; }
        public bool IsActive { get; set; }
        public Organization Organization { get; set; }
        public ICollection<EmergencyRequest> EmergencyRequests { get; set; }

    }
}
