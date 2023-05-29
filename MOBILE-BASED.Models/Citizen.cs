using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class Citizen : Person
    {
        public int CitizenId { get; set; }
        public ICollection<EmergencyRequest> EmergencyRequests { get; set; }

    }
}
