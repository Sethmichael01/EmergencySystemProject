using AutoMapper;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class CitizenCQ : ICrudInteger<CitizenVm>
    {
        private readonly IRepo<Citizen> _repo;
        private readonly IMapper _mapper;

        public CitizenCQ(IRepo<Citizen> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CitizenVm>> GetAll()
        {
            return _mapper.Map<List<CitizenVm>>(await _repo.GetAll());
        }

        public async Task<CitizenVm> GetById(int id)
        {
            return _mapper.Map<CitizenVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(CitizenVm vm)
        {
            var model = _mapper.Map<Citizen>(vm);

            string message;
            if (model.CitizenId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.CitizenId} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.CitizenId} Created Successfully";
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
                Message = result.Status ? "Organization has been deleted successfully" : result.Message
            };
        }
    }
}
