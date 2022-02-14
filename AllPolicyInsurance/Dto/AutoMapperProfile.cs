using AllPolicyInsurance.Models;
using AutoMapper;

namespace AllPolicyInsurance.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<InsurancePolicy, PolicyDTO>();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<PolicyRequestDTO, InsurancePolicy>().ReverseMap();
        }
    }
}
