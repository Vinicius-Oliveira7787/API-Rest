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
        private readonly IUsersService _usersService;
        public readonly IRepository<User> _usersRepository;
        
        public ApprovedStudentsController(
            IUsersService usersService,
            IRepository<User> usersRepository
        )
        {
            _usersService = usersService;
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
