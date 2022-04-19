using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINU.Model
{
    [Table("Grades")]
    public class GradeInfo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public decimal Grade { get; set; }
        [ForeignKey("SubjectProfesor")]
        public int SubjectProfesorId { get; set; }
        public SubjectProfesor SubjectProfesor { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
        //public User User { get; set; }

    }
}
