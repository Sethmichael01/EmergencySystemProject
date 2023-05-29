using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MOBILE_BASED.DAL;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models.APIAccountModels;
using MOBILE_BASED.Models.Constant;
using MOBILE_BASED.ViewModels;
using MOBILE_BASED.ViewModels.APIResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ICrudInteger<CitizenVm> _citizenRepo;
        private readonly ICommonQuery _commonQuery;

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,
            ICrudInteger<CitizenVm> citizenRepo, IMapper mapper, ICommonQuery commonQuery)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _citizenRepo = citizenRepo;
            _commonQuery = commonQuery;

        }
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var appUser = await _commonQuery.GetStaffByEmail(user.Email);
                CitizenVm citizenVm = new CitizenVm();
                if (appUser == null)
                {
                    citizenVm = await _commonQuery.GetCitizenByEmail(user.Email);
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                var dataModel = new LoginResponseModel { UserId = appUser != null ? appUser.StaffId : citizenVm.CitizenId, UserRole = userRoles.FirstOrDefault() };
                return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(dataModel) });
            }
            return Unauthorized(new HttpResult { Status = 401, Data = "" });
        }
        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var res = new ResponseVm();
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return Ok(new HttpResult { Status = 500, Data = JsonConvert.SerializeObject(res) });
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                EmailConfirmed = true,
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return Ok(new HttpResult { Status = 500, Data = JsonConvert.SerializeObject(result) });
            await _userManager.AddToRoleAsync(user, Roles.Citizen.ToString());
            res = await _citizenRepo.AddOrUpdate(_mapper.Map<CitizenVm>(model));
            if (res.Status)
                return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(new ResponseVm { Status = true, Message = "User created successfully!" }) });
            return Unauthorized(new HttpResult { Status = 401, Data = "" });
        }
    }
}
