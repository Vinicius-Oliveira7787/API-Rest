using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IExamService _examsService;
        
        public UsersController(IUsersService usersService, IExamService examService)
        {
            _usersService = usersService;
            _examsService = examsService;
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

            var response = _usersService.Create(
                request.Name,
                request.Profile,
                request.Email,
                request.Password
            );

            var createExam = 

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _usersService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
    }
}
