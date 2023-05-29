
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using MOBILE_BASED.DAL;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Services
{
    public class UserContext : IUserContext
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private static readonly HttpContextAccessor Accessor = new HttpContextAccessor();
        public EmergencySystemDbContext _db { get; }
        private readonly IHttpClientFactory _clientFactory;

        public UserContext(EmergencySystemDbContext db, UserManager<ApplicationUser> userManager, IHttpClientFactory clientFactory)
        {
            _db = db;
            _userManager = userManager;
            _clientFactory = clientFactory;
        }

        public string GetUserId()
        {
            return Accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserEmail()
        {
            return Accessor.HttpContext.User.Identity.Name;
        }

        public bool IsInRole(string role)
        {
            return Accessor.HttpContext.User.IsInRole(role);
        }

        public async Task<List<string>> GetUserRoles()
        {
            if (Accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var appUser = await _userManager.FindByIdAsync(GetUserId());

                var roleNames = await _userManager.GetRolesAsync(appUser);
                return roleNames.ToList();
            }
            return new List<string>();
        }

        public int GetInformationUserId()
        {
            if (Accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = GetUserId();
                return _db.Staffs.Where(x => x.StaffNumber.Equals(userId)).Select(s => s.StaffId).FirstOrDefault();
            }
            return 0;
        }

        public bool IsAuthenticated()
        {
            return Accessor.HttpContext.User.Identity.IsAuthenticated;
        }


    }
}
