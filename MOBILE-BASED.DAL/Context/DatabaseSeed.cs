using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.Context
{
    public static class DatabaseSeed
    {
        public static void PopulateUserRole(ModelBuilder builder)
        {
            // any guid
            string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e513";
            string SUPERADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e613";
            // any guid, but nothing is against to use the same one
            string ROLE_ID = ADMIN_ID;
            string SUPERROLE_ID = SUPERADMIN_ID;
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = ROLE_ID, Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = SUPERROLE_ID, Name = "SuperAdmin", NormalizedName = "SUPERADMIN" });


            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "Admin@emergencysystem.com",
                Email = "Admin@emergencysystem.com",
                NormalizedUserName = "ADMIN@EMERGENCYSYSTEM.COM",
                NormalizedEmail = "ADMIN@EMERGENCYSYSTEM.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@12345"),
                SecurityStamp = string.Empty
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = SUPERADMIN_ID,
                UserName = "SuperAdmin@emergencysystem.com",
                Email = "SuperAdmin@emergencysystem.com",
                NormalizedUserName = "SUPERADMIN@EMERGENCYSYSTEM.COM",
                NormalizedEmail = "SUPERADMIN@EMERGENCYSYSTEM.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "superadmin@12345"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = SUPERROLE_ID,
                UserId = SUPERADMIN_ID
            });
        }
    }
}
