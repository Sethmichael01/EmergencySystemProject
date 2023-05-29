using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

namespace MOBILE_BASED.Web.Controllers
{
    [Authorize(Roles = "Staff")]
    public class StaffsController : Controller
    {
        private readonly ICrudInteger<StaffVm> _repo;
        private readonly ICrudInteger<OrganizationVm> _orgQuery;
        public StaffsController(
            ICrudInteger<StaffVm> repo, 
            ICrudInteger<OrganizationVm> orgQuery)
        {
            _repo = repo;
            _orgQuery = orgQuery;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _repo.GetById((int)id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["OrganizationId"] = new SelectList(await _orgQuery.GetAll(), "OrganizationId", "OrganizationName");
            if (id > 0)
            {
                var state = await _repo.GetById(id);
                return View(state);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(StaffVm staff)
        {
            ViewData["OrganizationId"] = new SelectList(await _orgQuery.GetAll(), "OrganizationId", "OrganizationName", staff.OrganizationId);
            await _repo.AddOrUpdate(staff);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
