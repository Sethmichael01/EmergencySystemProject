using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOBILE_BASED.ViewModels
{
    public class CitizenVm
    {
        public int CitizenId { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
