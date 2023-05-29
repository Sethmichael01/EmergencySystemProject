using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models.AuthenticationModels
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
    }
}
