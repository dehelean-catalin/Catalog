using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SINU.DTO;
using SINU.Repository;
using SINU.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SINU.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public AuthController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO dto)
        {
            if (usersRepository.VerifyUniqueEmail(dto.Email))
            {
                var user = usersRepository.GetUserByIDNP(dto.IDNP);
                if (user != null)
                {
                    if (user.IDNP == user.Email)
                    {
                        var registeredUser = usersRepository.Register(mapper.Map<User>(dto));
                        if (registeredUser != null)
                        {
                            return Ok(mapper.Map<UserInfoDTO>(registeredUser));
                        }
                        else
                        {
                            return BadRequest("Error on registering. Try again.");
                        }
                    }
                    else
                    {
                        return BadRequest("User is already registered.");
                    }
                }
                else
                {
                    return NotFound("User with IDNP not found.");
                }
            }
            else
            {
                return BadRequest("Email is already used.");
            }
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = usersRepository.GetUserByEmail(dto.Email);
            if (user == null) return NotFound("User not registered.");
            if (user.Password != dto.Password) return BadRequest("Incorrect password.");
            return Ok(mapper.Map<UserInfoDTO>(user));
        }
    }
}
