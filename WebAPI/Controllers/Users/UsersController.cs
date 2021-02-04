using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile == Profile.Student)
            {
                return Unauthorized();
            }

            var allUsers = _usersService.GetAll();
            var studentsCounter = allUsers.Select(user => user.Profile == Profile.Student).Count();
            if (studentsCounter > 99)
            {
                return Unauthorized("limite excedido");
            }

            var response = _usersService.Create(
                request.Name,
                request.Profile,
                request.Email,
                request.Password
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _usersService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _usersService.GetAll();
            var approvedStudents = users
                .Where(user => user.Profile == Profile.Student && user.Score >= 7)
                .ToList();

            return Ok(approvedStudents);
        }
    }
}
