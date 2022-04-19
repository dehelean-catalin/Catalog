namespace SINU.DTO
{
    public class GradeCreateDTO
    {
        public int StudentId { get; set; }
        public decimal Grade { get; set; }
        public int SubjectId { get; set; }
        public int SubjectProfesorId { get; set; }
    }
}
