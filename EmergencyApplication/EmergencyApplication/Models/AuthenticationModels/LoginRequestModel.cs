using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication.Models.AuthenticationModels
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
