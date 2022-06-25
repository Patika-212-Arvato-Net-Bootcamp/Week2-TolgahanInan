using AutoMapper;
using Week2_Tolgahaninan.Models;
using Week2_Tolgahaninan.Models.Dtos;
namespace Week2_Tolgahaninan.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Bootcamp, BootcampDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
