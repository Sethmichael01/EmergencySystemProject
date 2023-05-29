using EmergencyApplication.Models;
using EmergencyApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmergencyApplication
{
    public static class AppSettings
    {
        public static readonly string BaseUrl = "https://192.168.0.180:45455/";
        public static readonly string RegisterUrl = "api/Account/Register";
        public static readonly string LoginUrl = "api/Account/Login";
        //public static readonly string GetUserProfile = "api/Citizens/GetCitizen?id=1";
        public static readonly string UpdateProfile = "api/Citizens/UpdateCitizen";
        public static readonly string AddOrUpdateEmergencyRequest = "api/EmergencyRequest/AddOrUpdate";
        //public static readonly string GetUserEmergencyRequests = "api/EmergencyRequest/GetUserEmergencyRequestList?userId=1&role=Citizen";
        public static readonly string GetSectors = "api/Sectors/GetSectors";

        public static string GetUserProfileEndpoint(int userId)
        {
            return $"api/Citizens/GetCitizen?id={userId}";
        }
        public static string GetUserEmergencyRequestListEndpoint(int userId, string userRole)
        {
            return $"api/EmergencyRequest/EmergencyRequestListForStaff?userId={userId}&role={userRole}";
        }

    }
}
