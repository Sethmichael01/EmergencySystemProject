using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Models.Roles
{
    public class RoleName
    {
        [Required]
        public string Roles { get; set; }
    }
}
