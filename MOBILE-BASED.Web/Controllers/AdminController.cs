using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MOBILE_BASED.DAL;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.Models.Constant;
using MOBILE_BASED.ViewModels;
using MOBILE_BASED.Web.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Controllers
{
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private readonly IMapper _mapper;
        private readonly ICommonQuery _commonQuery;
        private readonly ICrudInteger<StaffVm> _staffRepo;
        public AdminController(RoleManager<IdentityRole> roleMgr, ICrudInteger<StaffVm> staffRepo, IMapper mapper, ICommonQuery commonQuery, UserManager<ApplicationUser> userMrg)
        {
            roleManager = roleMgr;
            userManager = userMrg;
            _commonQuery = commonQuery;
            _staffRepo = staffRepo;
            _mapper = mapper;
        }
        public ViewResult Index() => View(roleManager.Roles);

        public IActionResult CreateRole() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);
                        if (result.Succeeded)
                        {
                            if (model.RoleName.Equals("Staff"))
                            {
                                StaffVm staffVm = new StaffVm
                                {
                                    Email = user.Email,
                                    IsActive = true,
                                    OrganizationName = "Health1",
                                    OrganizationId = 1,
                                    FirstName = user.FirstName,
                                    LastName = user.LastName,
                                };
                                var addStaff = await _staffRepo.AddOrUpdate(_mapper.Map<StaffVm>(staffVm));
                                var findCitizen = await _commonQuery.GetCitizenByEmail(staffVm.Email);
                                result = await userManager.RemoveFromRoleAsync(user, Roles.Citizen.ToString());
                            }
                        }

                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

    }
}
