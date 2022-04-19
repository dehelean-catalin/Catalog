using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SINU.Model
{
    [Table("Users")]
    public class User
    {
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [Required]
        public string IDNP { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }


    }
}
