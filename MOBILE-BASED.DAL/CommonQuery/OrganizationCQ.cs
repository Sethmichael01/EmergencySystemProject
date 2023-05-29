using AutoMapper;
using MOBILE_BASED.Infrastructure.Abstractions;
using MOBILE_BASED.Models;
using MOBILE_BASED.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MOBILE_BASED.DAL.CommonQuery
{
    public class OrganizationCQ : ICrudInteger<OrganizationVm>
    {
        private readonly IRepo<Organization> _repo;
        private readonly IMapper _mapper;

        public OrganizationCQ(IRepo<Organization> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<OrganizationVm>> GetAll()
        {
            return _mapper.Map<List<OrganizationVm>>(await _repo.GetAll($"{nameof(Sector)}"));
        }

        public async Task<OrganizationVm> GetById(int id)
        {
            return _mapper.Map<OrganizationVm>(await _repo.GetById(id));
        }
        public async Task<ResponseVm> AddOrUpdate(OrganizationVm vm)
        {
            var model = _mapper.Map<Organization>(vm);

            string message;
            if (model.OrganizationId > 0)
            {
                _repo.Update(model, _repo.UserId);
                message = $"{vm.OrganizationName} Updated Successfully";
            }
            else
            {
                await _repo.Save(model, _repo.UserId);
                message = $"{vm.OrganizationName} Created Successfully";
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
