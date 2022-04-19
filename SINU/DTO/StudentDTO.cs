using SINU.Model;

namespace SINU.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudyYearId { get; set; }
        public string StudyYearName { get; set; }

        //public StudentDTO()
        //{

        //}

        //public StudentDTO(Student student)
        //{
        //    Id = student.Id;
        //    ClassId = student.ClassId;
        //    UserId = student.UserId;
        //    StudyYearId = student.StudyYearId;
        //    FirstName = student.User.FirstName;
        //    LastName = student.User.LastName;
        //}

    }
}