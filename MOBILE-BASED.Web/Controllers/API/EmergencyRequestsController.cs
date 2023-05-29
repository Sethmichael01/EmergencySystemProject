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
    public class EmergencyRequestController : ControllerBase
    {
        private readonly ICrudInteger<EmergencyRequestVm> _repo;
        private readonly ICommonQuery _commonQuery;
        public EmergencyRequestController(ICrudInteger<EmergencyRequestVm> repo, ICommonQuery commonQuery)
        {
            _repo = repo;
            _commonQuery = commonQuery;
        }
        [HttpGet]
        [Route(nameof(GetUserEmergencyRequestList))]
        public async Task<IActionResult> GetUserEmergencyRequestList(int userId, string role)
        {
            //var response = GetUserEmergencyList(userId, role);
            //return EmergencyRequests.Where(x => x.CitizenId.Equals(userId));
            var response = await _commonQuery.GetUserEmergencyRequestList(userId, role);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });
        }
        [HttpGet]
        [Route(nameof(EmergencyRequestListForStaff))]
        public async Task<IActionResult> EmergencyRequestListForStaff(int userId, string role)
        {
            var response = await _commonQuery.EmergencyRequestListForStaff(userId, role);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });
        }
        [HttpPost]
        [Route(nameof(AddOrUpdate))]
        public async Task<IActionResult> AddOrUpdate(EmergencyRequestVm model)
        {
            if(model.EmergencyRequestId.Equals(0))
            {
                model.Status = "Pending";
            }
            var response = await _repo.AddOrUpdate(model);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });
        }


        [HttpPost]
        [Route(nameof(GetEmergency))]
        public async Task<IActionResult> GetEmergency(int id)
        {
            //var response = GetEmergencyById(id);
            var response = await _repo.GetById(id);
            return Ok(new HttpResult { Status = 200, Data = JsonConvert.SerializeObject(response) });

        }

        private static List<EmergencyRequestVm> emergencyRequests = new List<EmergencyRequestVm>();
       
        public List<EmergencyRequestVm> EmergencyRequests
        {
            get
            {
                if (emergencyRequests==null || !emergencyRequests.Any())
                    return null;
                return emergencyRequests;
            }
        }
        private ResponseVm AddOrUpdateEmergencyRequest(EmergencyRequestVm model)
        {
            if (model.EmergencyRequestId > 0)
            {
                var modelInList  = emergencyRequests.Where(i => i.EmergencyRequestId ==model.EmergencyRequestId).First();
                var index = emergencyRequests.IndexOf(modelInList);

                if (index != -1)
                    emergencyRequests[index] = model;
            }
            else
            {
                model.EmergencyRequestId = emergencyRequests.Count + 1;
                emergencyRequests.Add(model);

            }
            return new ResponseVm { Status = true, Message = "Committed Successfully" };
        }

        private List<EmergencyRequestVm> GetUserEmergencyList(int userId, string role)
        {
            if (emergencyRequests == null || !emergencyRequests.Any())
                return null;
            if (role == "Citizen")
            {
                return EmergencyRequests.Where(x => x.CitizenId.Equals(userId)).ToList();
            }
            else
            {
                return EmergencyRequests.Where(x => x.StaffId.Equals(userId)).ToList();
            }
             
        }
        private EmergencyRequestVm GetEmergencyById(int id)
        {
            if (emergencyRequests == null || !emergencyRequests.Any())
                return null;
            return EmergencyRequests.FirstOrDefault(x => x.EmergencyRequestId.Equals(id));
        }
    }
}
