using AutoMapper;
using Quizone.DTOS;
using Quizone.Models;

namespace Quizone.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDtos>()
                .ForMember(dest => dest.FullName
                , opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ForMember(dest => dest.Departmentname,
                           opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<TeacherCreateDtos, Teacher>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
                           .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
                     .ForMember(dest => dest.DepatmentId,
                    opt => opt.MapFrom(src => src.Dpid));


        }

    }
}

