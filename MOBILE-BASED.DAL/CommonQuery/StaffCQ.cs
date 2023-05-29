using AutoMapper;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class StaffCQ : ICrudInteger<StaffVm>
    {
        private readonly IRepo<Staff> _repo;
        private readonly IMapper _mapper;
        public StaffCQ(IRepo<Staff> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<StaffVm>> GetAll()
        {
            return _mapper.Map<List<StaffVm>>(await _repo.GetAll($"{nameof(Organization)}"));
        }

        public async Task<StaffVm> GetById(int id)
        {
            return _mapper.Map<StaffVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(StaffVm vm)
        {
            var model = _mapper.Map<Staff>(vm);

            string message;
            if (model.StaffId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{model.FirstName} {model.LastName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.StaffNumber} Created Successfully";
            }
            var result = await _repo.SaveContext();
            return new ResponseVm { Status = result.Status, Message = result.Status ? message : result.Message };
        }

        public async Task<ResponseVm> Delete(int id)
        {
            await _repo.Delete(id);
            var result = await _repo.SaveContext();
            return new ResponseVm
            {
                Status = result.Status,
                Message = result.Status ? "State has been deleted successfully" : result.Message
            };
        }
    }
}
