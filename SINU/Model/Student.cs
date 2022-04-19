using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SINU.Model
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StudyYear")]
        public int StudyYearId { get; set; }
        public StudyYear StudyYear { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }

    }
}
