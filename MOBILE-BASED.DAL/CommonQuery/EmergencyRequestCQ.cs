using AutoMapper;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class EmergencyRequestCQ : ICrudInteger<EmergencyRequestVm>
    {
        private readonly IRepo<EmergencyRequest> _repo;
        private readonly IMapper _mapper;

        public EmergencyRequestCQ(IRepo<EmergencyRequest> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<EmergencyRequestVm>> GetAll()
        {
            return _mapper.Map<List<EmergencyRequestVm>>(await _repo.GetAll($"{nameof(Sector)}"));
        }

        public async Task<EmergencyRequestVm> GetById(int id)
        {
            return _mapper.Map<EmergencyRequestVm>(await _repo.GetFirstOrDeafult(x => x.EmergencyRequestId.Equals(id), $"{nameof(Sector)}"));
        }
        public async Task<ResponseVm> AddOrUpdate(EmergencyRequestVm vm)
        {
            var model = _mapper.Map<EmergencyRequest>(vm);

            string message;
            if (model.EmergencyRequestId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.EmergencyRequestId} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.EmergencyRequestId} Created Successfully";
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
                Message = result.Status ? "Emergency Request has been deleted successfully" : result.Message
            };
        }
    }
}
