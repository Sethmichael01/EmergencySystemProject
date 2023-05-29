using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Models.Roles
{
    public class EditRoleVm
    {
        public EditRoleVm()
        {
            Users = new List<string>().ToList();
        }
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }


    }
}
