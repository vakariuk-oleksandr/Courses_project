using AutoMapper;
using Main_Project.BL.DTO;
using Main_Project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Main_Project.BL.Maping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, StudentDTO>().ForMember("StudentID", opt => opt.MapFrom(src => src.Id));
            CreateMap<User, RegisterDTO>().ReverseMap();
        }
    }
}
