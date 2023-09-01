using EmergencyApplication.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EmergencyApplication.Helper
{
    public static class GeoLocation
    {
        public static async Task<Location> GetLocationAsync()
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(80)
            });
            Location values = new Location();
            values.Longitude = location.Longitude;
            values.Latitude = location.Latitude;
            values.Altitude = location.Altitude;
            return values;
        }
        public static async Task<EmergencyRequest> GetEmergencyLocationAsync()
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Medium,
                Timeout = TimeSpan.FromSeconds(80)
            });
            EmergencyRequest values = new EmergencyRequest();
            values.Longitude = location.Longitude;
            values.Latitude = location.Latitude;
            values.Altitude = location.Altitude;
            return values;
        }
    }
}
