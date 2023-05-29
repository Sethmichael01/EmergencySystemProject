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
    public class StatesController : Controller
    {
        private readonly ICrudInteger<StateVm> _repo;

        public StatesController(ICrudInteger<StateVm> repo)
        {
            _repo = repo;
        }
        // GET: States
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
            var state = await _repo.GetById((int)id);
            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if(id > 0)
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
        public async Task<IActionResult> AddOrUpdate(StateVm state)
        {
            await _repo.AddOrUpdate(state);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
