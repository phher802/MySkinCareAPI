using AutoMapper;
using SkinCareAPI.Dtos;
using SkinCareAPI.Models;

namespace SkinCareAPI.Profiles
{
    //class inherits from Automapper.Profile
    public class SkinCaresProfile : Profile
    {
        //constructor
        public SkinCaresProfile()
        {
            //source: Models mapped to Target: SkinCareReadDto
            CreateMap<SkinCare, SkinCareReadDto>();
        }
    }
}