using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IUsersService _usersService;
        
        public ExamsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public IActionResult CreateExam(CreatePlayerRequest request) {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId)) {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null) {
                return Unauthorized();
            }

            if (user.Profile == Profile.Student)
            {
                return Unauthorized();
            }
            
        }

        // [HttpDelete("{id}")]
        // public IActionResult Remove(Guid id)
        // {
        //     StringValues userId;
        //     if(!Request.Headers.TryGetValue("UserId", out userId))
        //     {
        //         return Unauthorized();
        //     }

        //     var user = _usersService.GetById(Guid.Parse(userId));

        //     if (user == null)
        //     {
        //         return Unauthorized();
        //     }

        //     if (user.Profile != Profile.CBF)
        //     {
        //         return Unauthorized();
        //     }

        //     var playerRemoved = _playersService.Remove(id);

        //     if (playerRemoved == null)
        //     {
        //         return NotFound();
        //     }
            
        //     return NoContent();
        // }
    }
}
