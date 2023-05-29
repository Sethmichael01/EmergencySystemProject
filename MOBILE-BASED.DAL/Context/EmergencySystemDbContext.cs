using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using MOBILE_BASED.Models;

namespace MOBILE_BASED.DAL.Context
{
    public class EmergencySystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public EmergencySystemDbContext(DbContextOptions<EmergencySystemDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //DatabaseSeed.PopulateUserRole(builder);
        }

        public DbSet<State> States { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<LocalGovernment> LocalGovernments { get; set; }
        public DbSet<EmergencyRequest> EmergencyRequests { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
    }
}
