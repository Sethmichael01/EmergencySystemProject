using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MOBILE_BASED.DAL;
using MOBILE_BASED.DAL.CommonQuery;
using MOBILE_BASED.DAL.Concrete;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Infrastructure.Mapper;
using MOBILE_BASED.ViewModels;
using MOBILE_BASED.Web.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<EmergencySystemDbContext>(options =>
            //    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MOBILE-BASED.DB;Trusted_Connection=True;MultipleActiveResultSets=true"));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<EmergencySystemDbContext>();
            services.AddDbContext<EmergencySystemDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);
            // Adding Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpClient();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<EmergencySystemDbContext>()
            .AddDefaultTokenProviders();
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
            services.AddScoped(typeof(IUserContext), typeof(UserContext));
            services.AddScoped(typeof(ICrudInteger<SectorVm>), typeof(SectorCQ));
            services.AddScoped(typeof(ICrudInteger<OrganizationVm>), typeof(OrganizationCQ));
            services.AddScoped(typeof(ICrudInteger<EmergencyRequestVm>), typeof(EmergencyRequestCQ));
            services.AddScoped(typeof(ICrudInteger<StateVm>), typeof(StateCQ));
            services.AddScoped(typeof(ICrudInteger<CitizenVm>), typeof(CitizenCQ));
            services.AddScoped(typeof(ICrudInteger<StaffVm>), typeof(StaffCQ));
            services.AddScoped(typeof(ICrudInteger<CommunityVm>), typeof(CommunityCQ));
            services.AddScoped(typeof(ICrudInteger<LgaVm>), typeof(LocalGovernmentCQ));
            services.AddScoped<ICommonQuery, CommonQuery>();

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmergencySystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmergencySystem v1"));
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseDeveloperExceptionPage();

                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
