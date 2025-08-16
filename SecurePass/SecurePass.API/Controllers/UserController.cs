using System;
using SecurePass.Infraestructure.Data;
using SecurePass.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurePass.Domain.Entities;

namespace SecurePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SecurePassApplicationContext dbContext;

        public UserController(SecurePassApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.Users.ToList();

            return Ok(allUsers);
        }

        [HttpGet]
        [Route("id{id:int}")]

        public IActionResult GetUsertById(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        [HttpPost]
        public IActionResult AddUser(AddUserDto addUserDto)
        {
            var userEntity = new User
            {
                Id = addUserDto.Id,
                Name = addUserDto.Name,
                Email = addUserDto.Email,
                Password = addUserDto.Password,
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);

        }

        [HttpPut]
        [Route("id{id:int}")]

        public IActionResult UpdateUser(UpdateUserDto updateUserDto, int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }


            user.Name = updateUserDto.Name;
            user.Email = updateUserDto.Email;
            user.Password = updateUserDto.Password;

            dbContext.SaveChanges();

            return Ok(user);
        }


        [HttpDelete]
        [Route("id{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                NotFound();
            }

            dbContext.Users.Remove(user);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}