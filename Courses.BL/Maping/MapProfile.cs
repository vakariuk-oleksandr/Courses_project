using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Courses.BL
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Courses.Data.Courses, PostCoursesDTO>().ReverseMap();
        }
    }
}
