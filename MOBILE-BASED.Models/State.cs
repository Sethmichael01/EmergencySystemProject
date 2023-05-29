using System.Collections.Generic;

namespace MOBILE_BASED.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public ICollection<LocalGovernment> LocalGovernments { get; set; }
    }
   
}
