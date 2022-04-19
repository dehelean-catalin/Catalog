using System;
using SINU.Model;

namespace SINU.DTO
{
    public class GradeInfoDTO
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal Grade { get; set; }
        public int SubjectId { get; set; }
        public int SubjectProfesorId { get; set; }
        public DateTime Date { get; set; }
    }
}
