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
    public class LocalGovernmentsController : Controller
    {
        private readonly ICrudInteger<LgaVm> _repo;
        private readonly ICrudInteger<StateVm> _stateQuery;

        public LocalGovernmentsController(ICrudInteger<StateVm> stateQuery, ICrudInteger<LgaVm> repo)
        {
            _stateQuery = stateQuery;
            _repo = repo;
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

            var localGovernment = await _repo.GetById((int)id);
            if (localGovernment == null)
            {
                return NotFound();
            }

            return View(localGovernment);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName");
            if (id > 0)
            {
                var localGovernment = await _repo.GetById(id);
                return View(localGovernment);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(LgaVm localGovernment)
        {
            ViewData["StateId"] = new SelectList(await _stateQuery.GetAll(), "StateId", "StateName", localGovernment.StateId); 
            await _repo.AddOrUpdate(localGovernment);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
