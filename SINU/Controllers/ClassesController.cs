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
        private readonly IStudentsRepository studentsRepository;
        private readonly IGradesRepository gradesRepository;
        private readonly IMapper mapper;

        public ClassesController(IClassesRepository classesRepository, ISubjectsClassRepository subjectsClassRepository,
            IStudentsRepository studentsRepository, IGradesRepository gradesRepository, IMapper mapper)
        {
            this.subjectsClassRepository = subjectsClassRepository;
            this.classesRepository = classesRepository;
            this.studentsRepository = studentsRepository;
            this.gradesRepository = gradesRepository;
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
                return NotFound("Classes not found.");
            }
        }

        [HttpGet("{classId}")]
        public IActionResult Get(int classId)
        {
            var existingClass = classesRepository.GetClassById(classId);
            if (existingClass != null)
            {
                return Ok(mapper.Map<ClassDTO>(existingClass));
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound($"Class with id {classId} not found.");
            }
        }

        [HttpGet("{classId}/Detailed")]
        public IActionResult GetDetailed(int classId)
        {
            var existingClass = classesRepository.GetClassById(classId);
            if (existingClass != null)
            {
                var classInfo = mapper.Map<ClassInfoDTO>(existingClass);
                var subjects = subjectsClassRepository.GetSubjectClassByClassId(classId);
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
                return NotFound($"Class with id {classId} not found.");
            }
        }

        [HttpGet("{classId}/Subjects")]
        public IActionResult GetSubjects(int classId)
        {

            if (classesRepository.GetClassById(classId) != null)
            {
                var subjects = subjectsClassRepository.GetSubjectClassByClassId(classId);
                if (subjects != null)
                {
                    return Ok(subjects.ConvertAll(s => mapper.Map<SubjectClassDTO>(s)));
                    //return Ok(mapper.Map<ClassInfoDTO>(subjects));
                }
                else
                {
                    return BadRequest("There is no subjects for ClassId = " + classId);
                }
            }
            else
            {
                return NotFound(new { message = $"Class with id {classId} not found." });
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

        [HttpGet("{classId}/Students")]
        public IActionResult GetStudentsByClassId(int classId)
        {
            if (classesRepository.GetClassById(classId) != null)
            {
                var students = studentsRepository.GetStudentsByClassId(classId);
                if (students.Count > 0)
                {
                    return Ok(students.ConvertAll(s => mapper.Map<StudentDTO>(s)));
                }
                else
                {
                    //return BadRequest("There is no class with id = " + id);
                    return NotFound("No students in this class.");
                }
            }
            else
            {
                return NotFound($"Class with id {classId} not found.");
            }
        }

        [HttpGet("{classId}/GradesDetailed")]
        public IActionResult GetGradesByClassId(int classId)
        {
            if (classesRepository.GetClassById(classId) != null)
            {
                var gradesList = subjectsClassRepository.GetSubjectClassByClassId(classId).ConvertAll(s => mapper.Map<GradesPerSubjectDTO>(s));


                var subjectsClass = subjectsClassRepository.GetSubjectClassByClassId(classId);
                if (subjectsClass.Count > 0)
                {
                    var students = studentsRepository.GetStudentsByClassId(classId);
                    if (students.Count > 0)
                    {
                        foreach (var subjectClass in subjectsClass)
                        {
                            gradesList.Find(x => x.SubjectId == subjectClass.SubjectId)
                                        .Students = students.ConvertAll(s => mapper.Map<StudentGradesDTO>(s));
                            foreach (Student student in students)
                            {
                                List<GradeInfo> grades = gradesRepository.GetGradesPerSubjectByStudentId(student.Id, subjectClass.SubjectId);
                                if (grades.Count > 0)
                                {
                                    gradesList.Find(x => x.SubjectId == subjectClass.SubjectId)
                                        .Students.Find(s => s.StudentId == student.Id)
                                        .Grades.AddRange(grades.ConvertAll(s => mapper.Map<GradeMinimalisticDTO>(s)));
                                }
                            }
                        }
                    }
                    return Ok(gradesList);
                }
                else
                {
                    //return BadRequest("There is no class with id = " + id);
                    return NotFound("No students in this class.");
                }
            }
            else
            {
                return NotFound($"Class with id {classId} not found.");
            }
        }


        [HttpGet("{classId}/Grades")]
        public IActionResult GetGradessByClassId(int classId)
        {
            if (classesRepository.GetClassById(classId) != null)
            {
                var gradesList = new List<GradeInfoDTO>();


                var subjectsClass = subjectsClassRepository.GetSubjectClassByClassId(classId);
                if (subjectsClass.Count > 0)
                {
                    var students = studentsRepository.GetStudentsByClassId(classId);
                    if (students.Count > 0)
                    {
                        foreach (var subjectClass in subjectsClass)
                        {
                            foreach (Student student in students)
                            {
                                //List<GradeInfo> grades = gradesRepository.GetGradesPerSubjectByStudentId(student.Id, subjectClass.SubjectId);
                                //if (grades.Count > 0)
                                //{
                                //    gradesList.Find(x => x.SubjectId == subjectClass.SubjectId).Grades.AddRange(grades.ConvertAll(s => mapper.Map<GradeInfoDTO>(s)));
                                //}
                                gradesList.AddRange(gradesRepository.GetGradesPerSubjectByStudentId(student.Id, subjectClass.SubjectId).ConvertAll(s => mapper.Map<GradeInfoDTO>(s)));
                            }
                        }
                    }
                    return Ok(gradesList);
                }
                else
                {
                    //return BadRequest("There is no class with id = " + id);
                    return NotFound("No students in this class.");
                }
            }
            else
            {
                return NotFound($"Class with id {classId} not found.");
            }
        }
    }
}
