using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Domain.Exams;

namespace WebAPI.Controllers.Exams
{
    [ApiController]
    [Route("[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IExamsService _examsService;
        
        public ExamsController(IUsersService usersService, IExamsService examsService) {
            _usersService = usersService;
            _examsService = examsService;
        }

        [HttpPost]
        public IActionResult CreateExam(CreateExamRequest request) {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId)) {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null) {
                return Unauthorized();
            }

            if (user.Profile == Profile.Student) {
                return Unauthorized();
            }

            var response = _examsService.Create(request.Questions);

            if (!response.IsValid) {
                return BadRequest(response.Errors);
            }
            
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) {
            var exam = _examsService.GetById(id);

            if (exam == null) {
                return NotFound();
            }

            return Ok();
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
