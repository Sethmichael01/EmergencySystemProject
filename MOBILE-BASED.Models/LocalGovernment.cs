using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class LocalGovernment
    {
        public int LocalGovernmentId { get; set; }
        public int StateId { get; set; }
        public string LgaCode { get; set; }
        public string LgaName { get; set; }
        public State State { get; set; } 
        public ICollection<Community> Communities { get; set; }
    }
}
