using System;
using System.Collections.Generic;
using System.Text;

namespace MOBILE_BASED.ViewModels
{
    public class StaffVm
    {
        public int StaffId { get; set; }
        public int OrganizationId { get; set; }
        public string StaffNumber { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
