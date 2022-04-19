using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINU.Model
{
    [Table("SubjectsClass")]
    public class SubjectClass
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [ForeignKey("SubjectProfesor")]
        public int SubjectProfesorId { get; set; }
        public SubjectProfesor SubjectProfesor { get; set; }

    }
}
