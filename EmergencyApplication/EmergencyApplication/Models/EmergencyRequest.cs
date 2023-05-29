using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models
{
    public class EmergencyRequest
    {
        public int EmergencyRequestId { get; set; }
        public int CitizenId { get; set; }
        public int SectorId { get; set; }
        public int? StaffId { get; set; }
        public string Status { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double? Altitude { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string CitizenName { get; set; }
        public string SectorName { get; set; }
        public string StaffName { get; set; }
        public string Duration { get; set; }
        public string DisplayForCreatedDate => RequestTime.ToString("dd MMM yyyy");
        public string Title { get; set; }
        public string Comment { get; set; }
        public string DisplayForStatus => Status;

        public string DispalyForRequestTime
        {
            get
            {
                return RequestTime.ToString("hh:mm tt");
            }
        }
        public string DispalyForCompletedAt
        {
            get
            {
                if(CompletedAt.HasValue)
                    return CompletedAt.Value.ToString("hh:mm tt");
                return null;
            }
        }
    }
}
