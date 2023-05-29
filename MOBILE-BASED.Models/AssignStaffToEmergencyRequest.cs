using System;
using System.Collections.Generic;
using System.Text;

namespace MOBILE_BASED.Models
{
    public class AssignStaffToEmergencyRequest
    {
        public int AssignStaffToEmergencyRequestId { get; set; }
        public int StaffId { get; set; }
        public int EmergencyRequestId { get; set; }
        public bool Accepted { get; set; }
        public Staff Staff { get; set; }
        public EmergencyRequest EmergencyRequest { get; set; }
    }
}
