using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SINU.Model;
using SINU.Repository;
using SINU.DTO;
using AutoMapper;

namespace SINU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IStudyYearsRepository studyYearsRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentsRepository studentsRepository, IStudyYearsRepository studyYearsRepository, IMapper mapper)
        {
            this.studentsRepository = studentsRepository;
            this.studyYearsRepository = studyYearsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var studentsList = studentsRepository.GetAll().ConvertAll(s => mapper.Map<StudentDTO>(s));
            if (studentsList.Count > 0)
            {
                return Ok(studentsList);
            }
            else
            {
                //return BadRequest("There are no students.");
                return NotFound(new { message = "Students not found." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentByUserIdAndYearId(int id)
        {
            var currentYearId = studyYearsRepository.GetCurrentYearId();
            var student = studentsRepository.GetStudentByUserIdYearId(id, currentYearId);
            if (student != null)
            {
                return Ok(mapper.Map<StudentDTO>(student));
            }
            else
            {
                //return BadRequest("There is no student with id = " + id);
                return NotFound(new { message = $"Student with UserId {id} not found or isn't registered in current Year." });

            }
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{

        //    var student = studentsRepository.GetStudentById(id);
        //    if (student != null)
        //    {
        //        return Ok(mapper.Map<StudentDTO>(student));
        //    }
        //    else
        //    {
        //        //return BadRequest("There is no student with id = " + id);
        //        return NotFound(new { message = $"Student with id {id} not found." });

        //    }
        //}

        //[HttpPost]
        //public IActionResult Post(StudentDTO dto)
        //{
        //    var student = new Student()
        //    {
        //        ClassId = dto.ClassId,
        //        UserId = dto.UserId,
        //        StudyYearId = dto.StudyYearId
        //    };
        //    var newStudent = _repository.Create(student);
        //    if (newStudent != null)
        //    {
        //        return Ok(newStudent);
        //    }
        //    else
        //    {
        //        return BadRequest("Can't create this student.");
        //    }
        //}
    }
}
