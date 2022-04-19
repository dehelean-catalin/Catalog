using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SINU.DTO;

namespace SINU.Model
{
    [Table("Classes")]
    public class Class
    {
        [Key]
        public int Id { get;     set; }
        [Required]
        public string Number { get;     set; }
        [Required]
        public string Letter { get; set; }
        [Required]
        [ForeignKey("StudyYear")]
        public int StudyYearId { get; set; }
        public StudyYear StudyYear { get; set; }
        [ForeignKey("User")]
        public int MentorId { get; set; }
        public User Mentor { get; set; }


        public string GetFullName()
        {
            return this.Number + " " + this.Letter;
        }

    }

    
}
