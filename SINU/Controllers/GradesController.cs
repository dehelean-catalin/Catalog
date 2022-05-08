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
    public class GradesController : ControllerBase
    {
        private readonly ISubjectsProfesorRepository subjectsProfesorRepository;
        private readonly IGradesRepository gradesRepository;
        private readonly IStudentsRepository studentsRepository;
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public GradesController(IGradesRepository gradesRepository, IUsersRepository usersRepository,
                                ISubjectsProfesorRepository subjectsProfesorRepository,
                                IStudentsRepository studentsRepository, IMapper mapper)
        {
            this.subjectsProfesorRepository = subjectsProfesorRepository;
            this.studentsRepository = studentsRepository;
            this.gradesRepository = gradesRepository;
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            //var gradesList = gradesRepository.GetAll().ConvertAll(s => mapper.Map<GradeInfoDTO>(s));
            var gradesList = gradesRepository.GetAll().ConvertAll(s => mapper.Map<GradeInfoDTO>(s));

            if (gradesList.Count > 0)
            {
                return Ok(gradesList);
            }
            else
            {
                return NotFound("Grades not found.");
            }
        }


        [HttpGet("/student/{id}")]
        public IActionResult GetGradesByStudentId(int id)
        {
            var gradesList = gradesRepository.GetGradesByStudentId(id).ConvertAll(s => mapper.Map<GradeInfoDTO>(s));
            if (gradesList != null)
            {
                return Ok(gradesList);
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Grades not found for StudentId {id} not found.");
            }
        }

        [HttpGet("/{subjectId}/{studentId}")]
        public IActionResult GetGradesPerSubjectByStudentId(int studentId, int subjectId)
        {
            var gradesList = gradesRepository.GetGradesPerSubjectByStudentId(studentId, subjectId).ConvertAll(s => mapper.Map<GradeInfoDTO>(s));
            if (gradesList != null)
            {
                return Ok(gradesList);
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Grades not found.");
            }
        }




        [HttpGet("/teacher/{id}")]
        public IActionResult GetGradesByProfessorId(int id)
        {
            var gradesList = gradesRepository.GetGradesByProfessorId(id).ConvertAll(s => mapper.Map<GradeInfoDTO>(s));
            if (gradesList != null)
            {
                return Ok(gradesList);
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Grades not found for ProfesorId {id}.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGradeById(int id)
        {
            var grade = gradesRepository.GetGradeById(id);
            if (grade != null)
            {
                return Ok(mapper.Map<GradeInfoDTO>(grade));
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Grade not found for Id {id}.");
            }
        }




        [HttpGet("{id}/Detailed")]
        public IActionResult GetGradeDetailedById(int id)
        {
            var grade = gradesRepository.GetGradeById(id);
            if (grade != null)
            {
                return Ok(mapper.Map<GradeInfoDetailedDTO>(grade));
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Grade not found for Id {id}.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GradeModifyDTO gradeModifyDTO)
        {
            var grade = gradesRepository.GetGradeById(id);
            if (grade != null)
            {
                if (grade.SubjectProfesor.UserId == gradeModifyDTO.ProfesorUserId)
                {
                    grade.Grade = gradeModifyDTO.Grade;
                    var updatedGrade = gradesRepository.Update(grade);
                    if (updatedGrade != null)
                    {
                        return Ok(mapper.Map<GradeInfoDTO>(updatedGrade));
                    }
                    else
                    {
                        return BadRequest("something went wrong on updating. (Grade not updated)");
                    }
                }
                else
                {
                    return BadRequest("Only teacher who posted the Grade can update it.");
                }
            }
            else
            {
                return BadRequest("something went wrong on updating. (Grade not found)");
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, decimal value)
        //{
        //    var grade = gradesRepository.GetGradeById(id);
        //    if (grade != null)
        //    {
        //        grade.Grade = value;
        //        var updatedGrade = gradesRepository.Update(grade);
        //        if (updatedGrade != null)
        //        {
        //            return Ok(mapper.Map<GradeInfoDTO>(updatedGrade));
        //        }
        //        else
        //        {
        //            return BadRequest("something went wrong on updating. (Grade not updated)");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("something went wrong on updating. (Grade not found)");
        //    }
        //}

        [HttpPost()]
        public IActionResult Update(GradeCreateDTO gradeCreateDTO)
        {
            var addedGrade = gradesRepository.Create(mapper.Map<GradeInfo>(gradeCreateDTO));
            if (addedGrade != null)
            {
                return Ok(mapper.Map<GradeInfoDTO>(addedGrade));
            }
            else
            {
                return BadRequest("something went wrong on adding. (Grade not added)");
            }
        }

        [HttpDelete()]
        public IActionResult Delete(GradeDeleteDTO gradeDeleteDTO)
        {
            var grade = gradesRepository.GetGradeById(gradeDeleteDTO.GradeId);
            if (grade != null)
            {
                if (grade.SubjectProfesor.UserId == gradeDeleteDTO.ProfesorUserId)
                {
                    gradesRepository.Delete(grade);
                    return Ok("Grade deleted successfuly.");
                }
                else
                {
                    return BadRequest("Only teacher who posted the Grade can delete it.");
                }
            }
            else
            {
                return BadRequest("something went wrong on deleting. (Grade not found)");
            }
        }
    }
}
