using AutoMapper;
using Models.domain;

namespace Models.Application
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<TeacherVm, Teachers>();
            CreateMap<Teachers, TeacherVm>();
            CreateMap<FormVm, Studyingform>();
            CreateMap<Studyingform, FormVm>();
            CreateMap<SpecializationVm, Specialization>();
            CreateMap<Specialization, SpecializationVm>();
        }
    }
}
