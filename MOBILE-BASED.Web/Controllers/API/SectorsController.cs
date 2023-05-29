using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using MOBILE_BASED.ViewModels.APIResponseModels;
using Newtonsoft.Json;

namespace MOBILE_BASED.Web.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ICrudInteger<SectorVm> _repo;

        public SectorsController(ICrudInteger<SectorVm> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route(nameof(GetSectors))]
        public async Task<IActionResult> GetSectors()
        {
            //var response = sectorVms;
            var response = await _repo.GetAll();
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });
        }

        private List<SectorVm> sectorVms = new List<SectorVm>
        {
            new SectorVm{SectorId=1, SectorCode="HTH", SectorName="HEALTH"},
            new SectorVm{SectorId =2, SectorCode="SEC", SectorName="SECURITY"},
        };
       
    }
}
