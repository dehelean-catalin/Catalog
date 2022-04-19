using SINU.Model;

namespace SINU.DTO
{
    public class SubjectClassDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int SubjectProfesorId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
    }
}