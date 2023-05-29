using AutoMapper;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class CommunityCQ : ICrudInteger<CommunityVm>
    {
        private readonly IRepo<Community> _repo;
        private readonly IMapper _mapper;

        public CommunityCQ(IRepo<Community> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        public async Task<List<CommunityVm>> GetAll()
        {
            return _mapper.Map<List<CommunityVm>>(await _repo.GetAll($"{nameof(LocalGovernment)}"));
        }

        public async Task<CommunityVm> GetById(int id)
        {
            return _mapper.Map<CommunityVm>(await _repo.GetFirstOrDeafult(x=>x.CommunityId.Equals(id), $"{nameof(LocalGovernment)}"));
        }

        public async Task<ResponseVm> AddOrUpdate(CommunityVm vm)
        {
            var model = _mapper.Map<Community>(vm);

            string message;
            if (model.CommunityId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.CommunityName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.CommunityName} Created Successfully";
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
                Message = result.Status ? "Community has been deleted successfully" : result.Message
            };
        }

    }
}
