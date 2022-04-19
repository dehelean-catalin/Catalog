using Microsoft.AspNetCore.Mvc;
using SINU.DTO;
using SINU.Repository;
using AutoMapper;

namespace SINU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ISubjectsProfesorRepository subjectsProfesorRepository;
        private readonly IUsersRepository usersRepository;
        private readonly ISubjectsRepository subjectsRepository;
        private readonly IMapper mapper;


        public TeachersController(ISubjectsProfesorRepository subjectsProfesorRepository, IUsersRepository usersRepository, ISubjectsRepository subjectsRepository, IMapper mapper)
        {
            this.subjectsProfesorRepository = subjectsProfesorRepository;
            this.usersRepository = usersRepository;
            this.subjectsRepository = subjectsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var teachersDTOList = usersRepository.GetTeachers().ConvertAll(x => new TeacherDTO(x));
            var teachersDTOList = usersRepository.GetTeachers().ConvertAll(x => mapper.Map<TeacherDTO>(x));
            if (teachersDTOList.Count > 0)
            {
                return Ok(teachersDTOList);
            }
            else
            {
                return NotFound(new { message = "Teachers not found." });
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingUser = usersRepository.GetTeacherById(id);
            if (existingUser != null)
            {
                //return Ok(new TeacherDTO(existingUser));
                return Ok(mapper.Map<TeacherDTO>(existingUser));
            }
            else
            {
                return NotFound(new { message = $"Teacher with id {id} not found / user is not teacher." });
            }
        }

        [HttpGet("{id}/Subjects")]
        public IActionResult GetTeacherMaterials(int id)
        {
            var teacher = usersRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound(new { message = $"Teacher with id {id} not found / user is not teacher." });
            }
            else
            {
                //var subjectProfesorVMList = subjectsProfesorRepository.GetSubjectsProfesorByTeacherId(id).ConvertAll(x => new SubjectProfesorDTO(x));
                var subjectProfesorDTOList = subjectsProfesorRepository.GetSubjectsProfesorByTeacherId(id)
                    .ConvertAll(x => mapper.Map<SubjectProfesorDTO>(x));
                if (subjectProfesorDTOList.Count > 0)
                {
                    return Ok(subjectProfesorDTOList);
                }
                else
                {
                    return NotFound(new { message = "Teacher has no subjects." });
                }
            }

        }
    }
}
