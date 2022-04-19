using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SINU.DTO;
using SINU.Model;
using SINU.Repository;

namespace SINU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;
        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var usersList = usersRepository.GetAll();
            if (usersList.Count > 0)
            {
                //return Ok(usersList.ConvertAll(x => new UserInfoDTO(x)));
                return Ok(usersList.ConvertAll(x => mapper.Map<UserInfoDTO>(x)));
            }
            else
            {
                return NotFound(new { message = "Users not found." });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingUser = usersRepository.GetUserById(id);
            if (existingUser != null)
            {
                return Ok(mapper.Map<UserInfoDTO>(existingUser));
            }
            else
            {
                //return BadRequest("There is no class with id = " + id);
                return NotFound(new { message = $"User with id {id} not found." });
            }
        }

        [HttpPost]
        public IActionResult Create(UserInsertDTO userInsertDTO)
        {
            User user = mapper.Map<User>(userInsertDTO);

            user = usersRepository.Insert(user);
            if (user != null)
            {
                return Ok(mapper.Map<UserInfoDTO>(user));
                //return Ok(new UserInfoDTO(user));
            }
            else
            {
                return BadRequest(new { message = "Can't create user." });
            }
        }


        [HttpPut("{id}/UpdateProfile")]
        public IActionResult UpdateSettings(int id, SettingsDTO dto)
        {
            var user = usersRepository.GetUserById(id);
            if (user != null)
            {
                user.Address = dto.Address;
                user.Email = dto.Email;
                user.Phone = dto.Phone;
                var updatedUser = usersRepository.UpdateSettings(user); ;
                if (updatedUser != null)
                {
                    return Ok(mapper.Map<UserInfoDTO>(updatedUser));
                }
                else
                {
                    return BadRequest("something went wrong on updating. (User not updated)");
                }
            }
            else
            {
                return BadRequest("something went wrong on updating. (User not found)");
            }

        }

        [HttpPut("{id}/ChangePassword")]
        public IActionResult UpdatePassword(int id, UserPasswordDTO userPasswordDTO)
        {
            var user = usersRepository.GetUserById(id);
            if (user != null)
            {
                if (user.Password == userPasswordDTO.OldPassword)
                {
                    user.Password = userPasswordDTO.NewPassword;
                    var updatedUser = usersRepository.UpdatePassword(user); ;
                    if (updatedUser != null)
                    {
                        return Ok("Password changed succesfully!");
                    }
                    else
                    {
                        return BadRequest("Something went wrong on password updating. (User not updated)");
                    }
                }
                else
                {
                    return BadRequest("Incorrect old password.");
                }
            }
            else
            {
                return BadRequest("Something went wrong on updating. (User not found)");
            }

        }


        [HttpGet("Detailed")]
        public IActionResult GetAllDetailed()
        {
            var usersList = usersRepository.GetAll();
            if (usersList.Count > 0)
            {
                return Ok(usersList);
            }
            else
            {
                return NotFound(new { message = "Users not found." });
            }
        }

    }
}
