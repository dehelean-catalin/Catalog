using System.Collections.Generic;
using SINU.Model;

namespace SINU.DTO {
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Letter { get; set; }
        public int StudyYearId { get; set; }
        public string StudyYearName { get; set; }
        public int MentorId { get; set; }
        public string MentorFirstName { get; set; }
        public string MentorLastName { get; set; }
    }

}