using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SINU.DTO;
using SINU.Model;
using SINU.Repository;
using AutoMapper;

namespace SINU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepository classesRepository;
        private readonly ISubjectsClassRepository subjectsClassRepository;
        private readonly IMapper mapper;

        public ClassesController(IClassesRepository classesRepository, ISubjectsClassRepository subjectsClassRepository, IMapper mapper)
        {
            this.subjectsClassRepository = subjectsClassRepository;
            this.classesRepository = classesRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var classesList = classesRepository.GetAll().ConvertAll(s => mapper.Map<ClassDTO>(s));
            if (classesList.Count > 0)
            {
                return Ok(classesList);
            }
            else
            {
                return NotFound(new { message = "Classes not found." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingClass = classesRepository.GetClassById(id);
            if (existingClass != null)
            {
                return Ok(mapper.Map<ClassDTO>(existingClass));
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound(new { message = $"Class with id {id} not found." });
            }
        }

        [HttpGet("{id}/Detailed")]
        public IActionResult GetDetailed(int id)
        {
            var existingClass = classesRepository.GetClassById(id);
            if (existingClass != null)
            {
                var classInfo = mapper.Map<ClassInfoDTO>(existingClass);
                var subjects = subjectsClassRepository.GetSubjectClassByClassId(id);
                if (subjects != null)
                {
                    classInfo.Subjects = subjects.ConvertAll(s => mapper.Map<SubjectClassDTO>(s));
                    return Ok(classInfo);
                }
                else
                {
                    //return BadRequest("There is no subjects for ClassId = " + id);
                    return Ok(classInfo);
                }
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound(new { message = $"Class with id {id} not found." });
            }
        }

        [HttpGet("{id}/Subjects")]
        public IActionResult GetSubjects(int id)
        {

            if (classesRepository.GetClassById(id) != null)
            {
                var subjects = subjectsClassRepository.GetSubjectClassByClassId(id);
                if (subjects != null)
                {
                    return Ok(subjects.ConvertAll(s => mapper.Map<SubjectClassDTO>(s)));
                    //return Ok(mapper.Map<ClassInfoDTO>(subjects));
                }
                else
                {
                    return BadRequest("There is no subjects for ClassId = " + id);
                }
            }
            else
            {
                return NotFound(new { message = $"Class with id {id} not found." });
            }

            //var existingClass = classesRepository.GetClassById(id);
            //if (existingClass != null)
            //{
            //    var subjects = subjectsClassRepository.GetSubjectClassByClassId(id);
            //    //return Ok(mapper.Map<ClassInfoDTO>(existingClass));
            //    return Ok(subjects);
            //}
            //else
            //{
            //    //return BadRequest("There is no class with id = " + id);
            //    return NotFound(new { message = $"Class with id {id} not found." });
            //}
        }
    }
}
