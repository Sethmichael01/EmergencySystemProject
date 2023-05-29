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
    public class CitizensController : Controller
    {
        private readonly ICrudInteger<CitizenVm> _repo;

        public CitizensController(ICrudInteger<CitizenVm> repo)
        {
            _repo = repo;
        }

        // GET: Citizens
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Citizens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = await _repo.GetById((int)id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id > 0)
            {
                var citizen = await _repo.GetById(id);
                return View(citizen);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(CitizenVm citizen)
        {
            await _repo.AddOrUpdate(citizen);
            return RedirectToAction(nameof(Index));
        }
        // GET: Citizens/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
