using System.Collections.Generic;
using SINU.Model;

namespace SINU.DTO {
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string IDNP { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Role { get; set; }


        public UserInfoDTO()
        {

        }

        public UserInfoDTO(User user)
        {
            this.Id = user.Id;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Username = user.Username;
            this.Email = user.Email;
            this.IDNP = user.IDNP;
            this.Address = user.Address;
            this.Phone = user.Phone;
            this.Nationality = user.Nationality;
            this.Role = user.Role;
        }

    }

}