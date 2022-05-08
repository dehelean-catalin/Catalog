using System.Collections.Generic;
using SINU.Model;

namespace SINU.DTO
{
    public class SubjectProfesorDTO
    {
        public int SubjectProfesorId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int StudyYearId { get; set; }
        public string StudyYearName { get; set; }
        public List<int> ClassIds { get; set; }

        //public SubjectProfesorDTO() { }
        //public SubjectProfesorDTO(SubjectProfesor subjectProfesor)
        //{
        //    this.SubjectProfesorId = subjectProfesor.Id;
        //    this.UserId = subjectProfesor.UserId;
        //    this.SubjectId = subjectProfesor.SubjectId;
        //    this.SubjectName = subjectProfesor.Subject.Name;
        //    this.StudyYearId = subjectProfesor.StudyYearId;
        //    this.StudyYearName = subjectProfesor.StudyYear.Year;
        //}
    }
}
