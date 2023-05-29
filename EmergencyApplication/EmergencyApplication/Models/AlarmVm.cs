using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models
{
    public class AlarmVm
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string DisplaySectorName => $"{SectorName} ALARM";
    }
}
