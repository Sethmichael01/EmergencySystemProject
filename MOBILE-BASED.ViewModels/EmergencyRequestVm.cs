using System;
using System.Collections.Generic;
using System.Text;

namespace MOBILE_BASED.ViewModels
{
    public class EmergencyRequestVm
    {
        public int EmergencyRequestId { get; set; }
        public int CitizenId { get; set; }
        public int SectorId { get; set; }
        public int? StaffId { get; set; }
        public string Status { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string CitizenName { get; set; }
        public string SectorName { get; set; }
        public string StaffName { get; set; }
    }
}
