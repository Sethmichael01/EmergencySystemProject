using AutoMapper;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class LocalGovernmentCQ : ICrudInteger<LgaVm>
    {
        private readonly IRepo<LocalGovernment> _repo;
        private readonly IMapper _mapper;

        public LocalGovernmentCQ(IRepo<LocalGovernment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<LgaVm>> GetAll()
        {
            return _mapper.Map<List<LgaVm>>(await _repo.GetAll($"{nameof(State)}"));
        }

        public async Task<LgaVm> GetById(int id)
        {
            return _mapper.Map<LgaVm>(await _repo.GetFirstOrDeafult(x => x.LocalGovernmentId.Equals(id), $"{nameof(State)}"));
        }

        public async Task<ResponseVm> AddOrUpdate(LgaVm vm)
        {
            var model = _mapper.Map<LocalGovernment>(vm);

            string message;
            if (model.LocalGovernmentId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.LgaName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.LgaName} Created Successfully";
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
                Message = result.Status ? "LGA has been deleted successfully" : result.Message
            };
        }
    }
}
