using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SINU.Model
{
    [Table("StudyYears")]
    public class StudyYear
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Year { get; set; }
    }
}
