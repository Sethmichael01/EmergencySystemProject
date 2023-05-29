using AutoMapper;

using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class SectorCQ : ICrudInteger<SectorVm>
    {
        private readonly IRepo<Sector> _repo;
        private readonly IMapper _mapper;
        public SectorCQ(IRepo<Sector> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SectorVm>> GetAll()
        {
            return _mapper.Map<List<SectorVm>>(await _repo.GetAll());
        }

        public async Task<SectorVm> GetById(int id)
        {
            return _mapper.Map<SectorVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(SectorVm vm)
        {
            var model = _mapper.Map<Sector>(vm);

            string message;
            if (model.SectorId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.SectorName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.SectorName} Created Successfully";
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
                Message = result.Status ? "Sector has been deleted successfully" : result.Message
            };
        }
    }
}
