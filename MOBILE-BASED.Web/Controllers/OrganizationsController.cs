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
    public class OrganizationsController : Controller
    {
        private readonly ICrudInteger<OrganizationVm> _repo;
        private readonly ICrudInteger<CommunityVm> _communityQuery;
        private readonly ICrudInteger<SectorVm> _sectorQuery;

        public OrganizationsController(
            ICrudInteger<OrganizationVm> repo, 
            ICrudInteger<CommunityVm> communityQuery,
            ICrudInteger<SectorVm> sectorQuery)
        {
            _communityQuery = communityQuery;
            _repo = repo;
            _sectorQuery = sectorQuery;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organization = await _repo.GetById((int)id);
            if (organization == null)
            {
                return NotFound();
            }

            return View(organization);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["CommunityId"] = new SelectList(await _communityQuery.GetAll(), "CommunityId", "CommunityName");
            ViewData["SectorId"] = new SelectList(await _sectorQuery.GetAll(), "SectorId", "SectorName");       
            if (id > 0)
            {
                var organization = await _repo.GetById(id);
                return View(organization);
            }
            else
            {
                return View();
            }            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(OrganizationVm organization)
        {
            ViewData["CommunityId"] = new SelectList(await _communityQuery.GetAll(), "CommunityId", "CommunityName", organization.CommunityId);
            ViewData["SectorId"] = new SelectList(await _sectorQuery.GetAll(), "SectorId", "SectorName", organization.SectorId);
            await _repo.AddOrUpdate(organization);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
