using System;
using SINU.Model;

namespace SINU.DTO
{
    public class GradeInfoDetailedDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudyYearId { get; set; }
        public string StudyYearName { get; set; }
        public decimal Grade { get; set; }
        public int SubjectProfesorId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectAbout { get; set; }
        public DateTime Date { get; set; }
    }
}
