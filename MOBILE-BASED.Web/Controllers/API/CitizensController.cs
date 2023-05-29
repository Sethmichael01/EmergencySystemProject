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
    public class CitizensController : ControllerBase
    {
        private readonly EmergencySystemDbContext _context;
        private readonly ICrudInteger<CitizenVm> _repo;

        public CitizensController(ICrudInteger<CitizenVm> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route(nameof(GetCitizen))]
        public async Task<IActionResult> GetCitizen(int id)
        {
            //var response = citizen;
            var response = await _repo.GetById(id);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });
        }

        [HttpPost]
        [Route(nameof(UpdateCitizen))]
        public async Task<IActionResult> UpdateCitizen(CitizenVm model)
        {
            //var response = new ResponseVm { Status = true, Message = "Committed Successfully" };
            var response = await _repo.AddOrUpdate(model);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });

        }

        private CitizenVm citizen = new CitizenVm
        {
            CitizenId = 1,
            FirstName = "Kenny",
            LastName = "Adejoro",
            Address = "Abuja",
            PhoneNumber = "07032661755",
            Email = "kehinde.adejoro01@gmail.com",
            DateOfBirth = DateTime.Now
        };

    }
}
