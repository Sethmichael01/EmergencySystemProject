using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Models.Roles
{
    public class UserRoleVm
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public bool isSelected { get; set; }
    }
}
