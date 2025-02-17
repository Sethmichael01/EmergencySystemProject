﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models
{
    public class CitizenMobileVm
    {
        public int CitizenId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
