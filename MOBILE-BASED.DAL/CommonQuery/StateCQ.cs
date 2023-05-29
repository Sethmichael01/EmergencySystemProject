using AutoMapper;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class StateCQ : ICrudInteger<StateVm>
    {
        private readonly IRepo<State> _repo;
        private readonly IMapper _mapper;

        public StateCQ(IRepo<State> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<List<StateVm>> GetAll()
        {
            return _mapper.Map<List<StateVm>>(await _repo.GetAll());
        }

        public async Task<StateVm> GetById(int id)
        {
            return _mapper.Map<StateVm>(await _repo.GetById(id));
        }

        public async Task<ResponseVm> AddOrUpdate(StateVm vm)
        {
            var model = _mapper.Map<State>(vm);

            string message;
            if (model.StateId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.StateName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.StateName} Created Successfully";
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
