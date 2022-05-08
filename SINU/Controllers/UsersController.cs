using System;
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
                return NotFound("Users not found.");
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
                return NotFound($"User with id {id} not found.");
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
                return BadRequest("Can't create user.");
            }
        }

        [HttpPost("UniqueEmail")]
        public IActionResult VerifyEmail(string email)
        {

            if (usersRepository.VerifyUniqueEmail(email))
            {
                return Ok();
                //return Ok(new UserInfoDTO(user));
            }
            else
            {
                return BadRequest("Email isn't unique.");
            }
        }


        [HttpPut("{id}/UpdateProfile")]
        public IActionResult UpdateSettings(int id, SettingsDTO dto)
        {
            var user = usersRepository.GetUserById(id);
            if (user != null)
            {
                user.Address = dto.Address;

                if (user.Email != dto.Email)
                {
                    if (usersRepository.VerifyUniqueEmail(dto.Email))
                    {
                        user.Email = dto.Email;
                    }
                    else
                    {
                        return BadRequest("Email isn't unique.");
                    }
                }

                if (user.Phone != dto.Phone)
                {
                    if (usersRepository.VerifyUniquePhone(dto.Phone))
                    {
                        user.Phone = dto.Phone;
                    }
                    else
                    {
                        return BadRequest("Phone number isn't unique.");
                    }
                }

                var updatedUser = usersRepository.UpdateSettings(user); ;
                if (updatedUser != null)
                {
                    return Ok(mapper.Map<UserInfoDTO>(updatedUser));
                }
                else
                {
                    return BadRequest("Error. User not updated.");
                }
            }
            else
            {
                return BadRequest("User not found.");
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
                        return BadRequest("error. Password doesn't change.");
                    }
                }
                else
                {
                    return BadRequest("Incorrect old password.");
                }
            }
            else
            {
                return BadRequest("User not found.");
            }

        }

        [HttpPost("{IDNP_or_Email}/Status")]
        public IActionResult GetRegisterStatus(string IDNP_or_Email)
        {
            if (IDNP_or_Email.Contains('@'))
            {
                var user = usersRepository.GetUserByEmail(IDNP_or_Email);
                if (user != null)
                {
                    //return Ok($"{{Registered: true, Role: {user.Role} }");
                    return Ok(new StatusDTO { UserId = user.Id, Registered = !(user.Email == user.IDNP), Role = user.Role });
                }
                else
                {
                    return BadRequest($"User with Email {IDNP_or_Email} not found.");
                }
            }
            else
            {
                var user = usersRepository.GetUserByIDNP(IDNP_or_Email);
                if (user != null)
                {
                    //return Ok($"{{Registered: true, Role: {user.Role} }");
                    return Ok(new StatusDTO { UserId = user.Id, Registered = !(user.Email == user.IDNP), Role = user.Role });
                }
                else
                {
                    return BadRequest($"User with IDNP {IDNP_or_Email} not found.");
                }
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
