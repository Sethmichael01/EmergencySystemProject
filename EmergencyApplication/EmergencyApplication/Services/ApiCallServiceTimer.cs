﻿using EmergencyApplication.Helper;
using EmergencyApplication.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace EmergencyApplication.Services
{
    public class ApiCallServiceTimer
    {
        private HttpClient _client;
        private Timer apiCallTimer;
        private HttpClientService<EmergencyRequest> _clientService = new HttpClientService<EmergencyRequest>();

        private EmergencyRequest request;

        public ApiCallServiceTimer()
        {
            _client = new HttpClient();

            // Start the timer
            Device.StartTimer(TimeSpan.FromSeconds(30), () =>
            {
                Task.Run(async () => await OnTimerTickAsync());
                return true;
            });
        }

        private async Task OnTimerTickAsync()
        {
            // Make the API call
            var location = await GeoLocation.GetLocationAsync();
            request.StaffLongitude = location.Longitude;
            request.StaffLatitude = location.Latitude;
            request.StaffAltitude = location.Altitude;
            // YourApiCall();
            var res = await _clientService.PostAsync(request, AppSettings.AddOrUpdateEmergencyRequest);
            if (res.StatusCode == 200)
            {
                //return true;
            }

            // Return true to continue the timer, or false to stop it
            //return true;
        }
    }
}
