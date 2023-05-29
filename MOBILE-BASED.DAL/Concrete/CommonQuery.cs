using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MOBILE_BASED.DAL.Context;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.Concrete
{
    public class CommonQuery : ICommonQuery
    {
        private readonly ICrudInteger<EmergencyRequestVm> _repo;
        private readonly EmergencySystemDbContext _db;
        private readonly IMapper _mapper;

        public CommonQuery(EmergencySystemDbContext db, IMapper mapper, ICrudInteger<EmergencyRequestVm> repo)
        {
            _db = db;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<CitizenVm> GetCitizenByEmail(string email)
        {
            return _mapper.Map<CitizenVm>(await _db.Citizens.FirstOrDefaultAsync(x => x.Email.Equals(email)));
        }

        public async Task<StaffVm> GetStaffByEmail(string email)
        {
            return _mapper.Map<StaffVm>(await _db.Staffs.FirstOrDefaultAsync(x => x.Email.Equals(email)));
        }

        public async Task<List<EmergencyRequestVm>> GetUserEmergencyRequestList(int userId, string role)
        {
            if (role == "Citizen")
            {
                var citizenRequests = await _db.EmergencyRequests
                    .Include(x => x.Staff)
                    .Include(x => x.Citizen)
                    .Include(x => x.Sector)
                    .AsNoTracking()
                    .Where(x => x.CitizenId.Equals(userId)).ToListAsync();
                return _mapper.Map<List<EmergencyRequestVm>>(citizenRequests);
            }
            else
            {
                var staffRequests = await _db.EmergencyRequests
                    .Include(x => x.Staff)
                    .Include(x => x.Citizen)
                    .Include(x => x.Sector)
                    .AsNoTracking()
                    .Where(x => x.StaffId.Equals(userId)).ToListAsync();
                return _mapper.Map<List<EmergencyRequestVm>>(staffRequests);
            }
        }
        public async Task<List<EmergencyRequestVm>> EmergencyRequestListForStaff(int userId, string role)
        {
            if (role == "Staff")
            {
                var citizenRequests = await _db.EmergencyRequests
                    .Include(x => x.Staff)
                    .Include(x => x.Citizen)
                    .Include(x => x.Sector)
                    .AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<EmergencyRequestVm>>(citizenRequests);
            }
            else
            {
                var citizenRequests = await _db.EmergencyRequests
                    .Include(x => x.Staff)
                    .Include(x => x.Citizen)
                    .Include(x => x.Sector)
                    .AsNoTracking()
                    .Where(x => x.CitizenId.Equals(userId)).ToListAsync();
                return _mapper.Map<List<EmergencyRequestVm>>(citizenRequests);
            }
        }
    }
}
