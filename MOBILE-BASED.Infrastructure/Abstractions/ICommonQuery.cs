using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.Infrastructure.Abstractions
{
    public interface ICommonQuery
    {
        Task<CitizenVm> GetCitizenByEmail(string email);
        Task<StaffVm> GetStaffByEmail(string email);
        Task<List<EmergencyRequestVm>> GetUserEmergencyRequestList(int userId, string role);
        Task<List<EmergencyRequestVm>> EmergencyRequestListForStaff(int userId, string role);

    }
}
