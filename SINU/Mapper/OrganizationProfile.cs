using AutoMapper;
using SINU.DTO;
using SINU.Model;

namespace SINU.Mapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<User, UserInsertDTO>().ReverseMap();

            CreateMap<User, UserInfoDTO>().ReverseMap();

            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, TeacherDTO>().ReverseMap();


            //CreateMap<SettingsDTO, User>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            //    .ReverseMap();

            CreateMap<Class, ClassDTO>()
                .ForMember(dest => dest.StudyYearName, opt => opt.MapFrom(src => src.StudyYear.Year))
                .ForMember(dest => dest.MentorFirstName, opt => opt.MapFrom(src => src.Mentor.FirstName))
                .ForMember(dest => dest.MentorLastName, opt => opt.MapFrom(src => src.Mentor.LastName))
                .ReverseMap();

            CreateMap<Class, ClassInfoDTO>()
                .ForMember(dest => dest.StudyYearName, opt => opt.MapFrom(src => src.StudyYear.Year))
                .ForMember(dest => dest.MentorFirstName, opt => opt.MapFrom(src => src.Mentor.FirstName))
                .ForMember(dest => dest.MentorLastName, opt => opt.MapFrom(src => src.Mentor.LastName))
                .ReverseMap();

            CreateMap<SubjectClass, SubjectClassDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.Subject.About))
                .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.SubjectProfesor.User.FirstName))
                .ForMember(dest => dest.TeacherLastName, opt => opt.MapFrom(src => src.SubjectProfesor.User.LastName))
                .ReverseMap();

            CreateMap<SubjectClass, GradesPerSubjectDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.Subject.About))
                .ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.SubjectProfesor.User.FirstName))
                .ForMember(dest => dest.TeacherLastName, opt => opt.MapFrom(src => src.SubjectProfesor.User.LastName))
                .ReverseMap();


            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.GetFullName()))
                .ForMember(dest => dest.StudyYearName, opt => opt.MapFrom(src => src.StudyYear.Year))
                .ReverseMap();

            CreateMap<Student, StudentGradesDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();



            CreateMap<GradeInfo, GradeInfoDTO>()
                //.ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Teacher.FirstName))
                //.ForMember(dest => dest.TeacherLastName, opt => opt.MapFrom(src => src.Teacher.LastName))
                .ReverseMap();

            CreateMap<GradeInfo, GradeInfoDetailedDTO>()
                //.ForMember(dest => dest.MentorFirstName, opt => opt.MapFrom(src => src.Mentor.FirstName))
                //.ForMember(dest => dest.MentorLastName, opt => opt.MapFrom(src => src.Mentor.LastName))
                .ReverseMap();

            CreateMap<GradeInfo, GradeMinimalisticDTO>()
                .ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<GradeCreateDTO, GradeInfo>()
                //.ForMember(dest => dest.TeacherFirstName, opt => opt.MapFrom(src => src.Teacher.FirstName))
                //.ForMember(dest => dest.TeacherLastName, opt => opt.MapFrom(src => src.Teacher.LastName))
                .ReverseMap();




            CreateMap<SubjectProfesor, SubjectProfesorDTO>()
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name))
                .ForMember(dest => dest.StudyYearName, opt => opt.MapFrom(src => src.StudyYear.Year))
                .ForMember(dest => dest.SubjectProfesorId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
        }
    }
}
