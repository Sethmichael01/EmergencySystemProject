using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.ViewModels;

using System.Threading.Tasks;

namespace MOBILE_BASED.Web.Controllers
{
    [Authorize(Roles = "Staff")]
    public class SectorsController : Controller
    {
        private readonly ICrudInteger<SectorVm> _repo;

        public SectorsController(ICrudInteger<SectorVm> repo)
        {
            _repo = repo;
        }

        // GET: Sectors
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: Sectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _repo.GetById((int)id);
            if (sector == null)
            {
                return NotFound();
            }

            return View(sector);
        }

        public async Task<IActionResult> AddOrUpdate(int id)
        {
            if (id > 0)
            {
                var sector = await _repo.GetById(id);
                return View(sector);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(SectorVm sector)
        {
            await _repo.AddOrUpdate(sector);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
