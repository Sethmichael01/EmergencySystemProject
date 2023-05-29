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
    public class CommunitiesController : Controller
    {
        private readonly ICrudInteger<CommunityVm> _repo;
        private readonly ICrudInteger<LgaVm> _lgaQuery;

        public CommunitiesController(
            ICrudInteger<CommunityVm> repo,
            ICrudInteger<LgaVm> lgaQuery)
        {
            _repo = repo;
            _lgaQuery = lgaQuery;
        }

        // GET: Communities
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Communities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _repo.GetById((int)id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }       

        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["LocalGovernmentId"] = new SelectList(await _lgaQuery.GetAll(), "LocalGovernmentId", "LgaName");
            if (id > 0)
            {
                var community = await _repo.GetById(id);
                return View(community);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(CommunityVm community)
        {
            ViewData["LocalGovernmentId"] = new SelectList(await _lgaQuery.GetAll(), "LocalGovernmentId", "LgaName", community.LocalGovernmentId);
            await _repo.AddOrUpdate(community);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
