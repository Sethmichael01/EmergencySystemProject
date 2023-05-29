using AutoMapper;

using MOBILE_BASED.Models;
using MOBILE_BASED.Models.APIAccountModels;
using MOBILE_BASED.ViewModels;

namespace MOBILE_BASED.Infrastructure.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<State, StateVm>().ReverseMap();
            CreateMap<LgaVm, LocalGovernment>();
            CreateMap<LocalGovernment, LgaVm>()
                .ForMember(vm => vm.StateName, o => o.MapFrom(source => source.State.StateName));

            CreateMap<CommunityVm, Community>();
            CreateMap<Community, CommunityVm>()
                .ForMember(vm => vm.LgaName, o => o.MapFrom(source => source.LocalGovernment.LgaName));

            CreateMap<OrganizationVm, Organization>();
            CreateMap<Organization, OrganizationVm>()
                .ForMember(vm => vm.SectorName, o => o.MapFrom(source => source.Sector.SectorName))
                .ForMember(vm => vm.CommunityName, o => o.MapFrom(source => source.Community.CommunityName));

            CreateMap<SectorVm, Sector>().ReverseMap();

            CreateMap<StaffVm, Staff>();
            CreateMap<Staff, StaffVm>()
                .ForMember(vm => vm.OrganizationName, o => o.MapFrom(source => source.Organization.OrganizationName));

            CreateMap<EmergencyRequestVm, EmergencyRequest>();
            CreateMap<EmergencyRequest, EmergencyRequestVm>()
                .ForMember(vm => vm.SectorName, o => o.MapFrom(source => source.Sector.SectorName))
                .ForMember(vm => vm.StaffName, o => o.MapFrom(source => source.Staff.FullName))
                .ForMember(vm => vm.CitizenName, o => o.MapFrom(source => source.Citizen.FullName));

            CreateMap<CitizenVm, Citizen>().ReverseMap();

            CreateMap<RegisterModel, CitizenVm>().ReverseMap();
        }
    }
}
