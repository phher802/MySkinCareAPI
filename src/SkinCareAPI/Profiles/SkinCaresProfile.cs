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

            //source: SkinCareCreateDto bc it will be supplied in the POST request body, mapped to the target: skincare model
            CreateMap<SkinCareCreateDto, SkinCare>();

            CreateMap<SkinCareUpdateDto, SkinCare>();

            CreateMap<SkinCare, SkinCareUpdateDto>();
        }
    }
}