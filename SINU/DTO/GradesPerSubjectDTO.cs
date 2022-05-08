using System.Collections.Generic;
using SINU.Model;

namespace SINU.DTO
{
    public class GradesPerSubjectDTO
    {
        public int SubjectId { get; set; }
        public int SubjectProfesorId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public List<StudentGradesDTO> Students { get; set; } = new List<StudentGradesDTO>();

    }
}
