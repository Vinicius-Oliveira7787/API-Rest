using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;
using Microsoft.Extensions.Primitives;
using Domain.Common;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovedStudentsController : ControllerBase
    {
        public readonly IRepository<User> _usersRepository;
        
        public ApprovedStudentsController(
            IRepository<User> usersRepository
        )
        {
            _usersRepository = usersRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentsThatPassed()
        {
            var users = _usersRepository
                .Get(users => users.BulletinNote >= 7 && users.Profile == Profile.Student);
            
            return Ok(users);
        }
    }
}
