using System.Collections.Generic;

namespace SINU.DTO
{
    public class StudentGradesDTO
    {
        public int StudentId { get; set; }
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<GradeMinimalisticDTO> Grades { get; set; } = new List<GradeMinimalisticDTO>();
    }
}
