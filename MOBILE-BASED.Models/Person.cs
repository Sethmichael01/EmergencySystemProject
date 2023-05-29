using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOBILE_BASED.Models
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{LastName} {FirstName}";       
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
