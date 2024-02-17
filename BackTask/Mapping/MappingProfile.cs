using AutoMapper;
using BackTask.Database.Entities;
using BackTask.Dto;

namespace BackTask.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();

        }
    }
}
