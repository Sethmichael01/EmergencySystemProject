using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOBILE_BASED.DAL;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System.Net;
using System.Net.Http;

namespace MOBILE_BASED.Web.Controllers
{
    public class EmergencyRequestsController : Controller
    {
        private readonly ICrudInteger<EmergencyRequestVm> _repo;
        private readonly ICrudInteger<CitizenVm> _citizenQuery;
        private readonly ICrudInteger<SectorVm> _sectorQuery;
        private readonly ICrudInteger<StaffVm> _staffQuery;
        private static UserManager<ApplicationUser> _userManager;
        public EmergencyRequestsController(
            ICrudInteger<StaffVm> staffQuery,
            ICrudInteger<SectorVm> sectorQuery, 
            ICrudInteger<CitizenVm> citizenQuery,
            UserManager<ApplicationUser> userManager,
            ICrudInteger<EmergencyRequestVm> repo)
        {
            _citizenQuery = citizenQuery;
            _sectorQuery = sectorQuery;
            _staffQuery = staffQuery;
            _userManager = userManager;
            _repo = repo;
        }

        // GET: EmergencyRequests
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: EmergencyRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyRequest = await _repo.GetById((int)id);
            if (emergencyRequest == null)
            {
                return NotFound();
            }

            return View(emergencyRequest);
        }
        public async Task<IActionResult> AddOrUpdate(int id)
        {
            ViewData["CitizenId"] = new SelectList(await _citizenQuery.GetAll(), "CitizenId", "FullName");
            ViewData["SectorId"] = new SelectList(await _sectorQuery.GetAll(), "SectorId", "SectorName");
            ViewData["StaffId"] = new SelectList(await _staffQuery.GetAll(), "StaffId", "FullName");
            if (id > 0)
            {
                var emergencyRequest = await _repo.GetById(id);
                return View(emergencyRequest);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrUpdate(EmergencyRequestVm emergencyRequest)
        {
            ViewData["CitizenId"] = new SelectList(await _citizenQuery.GetAll(), "CitizenId", "CitizenName", emergencyRequest.CitizenId);
            ViewData["SectorId"] = new SelectList(await _sectorQuery.GetAll(), "SectorId", "SectorName", emergencyRequest.SectorId);
            ViewData["StaffId"] = new SelectList(await _staffQuery.GetAll(), "StaffId", "StaffName", emergencyRequest.StaffId);
            //IPAddress remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            //string result = "";
            //if (remoteIpAddress != null)
            //{
            //    // If we got an IPV6 address, then we need to ask the network for the IPV4 address 
            //    // This usually only happens when the browser is on the same machine as the server.
            //    if (remoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            //    {
            //        remoteIpAddress = System.Net.Dns.GetHostEntry(remoteIpAddress).AddressList
            //.First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            //    }
            //    result = remoteIpAddress.ToString();
            //}
            //// IP API URL
            //var Ip_Api_Url = "http://ip-api.com/json/result"; // 206.189.139.232 - This is a sample IP address. You can pass yours if you want to test          

            //// Use HttpClient to get the details from the Json response
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //    // Pass API address to get the Geolocation details 
            //    httpClient.BaseAddress = new Uri(Ip_Api_Url);
            //    HttpResponseMessage httpResponse = httpClient.GetAsync(Ip_Api_Url).GetAwaiter().GetResult();
            //    If API is success and receive the response, then get the location details
            //    if (httpResponse.IsSuccessStatusCode)
            //    {
            //        var geolocationInfo = httpResponse.Content.ReadAsAsync<LocationDetails_IpApi>().GetAwaiter().GetResult();
            //        if (geolocationInfo != null)
            //        {
            //            geolocationInfo.lat =
            //            Console.WriteLine("Country: " + geolocationInfo.country);
            //            Console.WriteLine("Region: " + geolocationInfo.regionName);
            //            Console.WriteLine("City: " + geolocationInfo.city);
            //            Console.WriteLine("Zip: " + geolocationInfo.zip);
            //            Console.ReadKey();
            //        }
            //    }
            //}
            emergencyRequest.Status = "Pending";
            if(emergencyRequest.Status == "Arrived")
            {
                emergencyRequest.ArrivalTime = DateTime.Now;
            }
            else if(emergencyRequest.Status == "Complete")
            {
                emergencyRequest.CompletedAt = DateTime.Now;
            }            
            emergencyRequest.RequestTime = DateTime.Now;
            await _repo.AddOrUpdate(emergencyRequest);
            return RedirectToAction(nameof(Index));
        }
        // GET: EmergencyRequests/Delete/5
        public async Task<IActionResult> Delete(int Id)
        {
            await _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
        public class LocationDetails_IpApi
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
    }
}
