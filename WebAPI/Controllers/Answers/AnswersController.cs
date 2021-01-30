using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Domain.Answers;
using System.Linq;

namespace WebAPI.Controllers.Answers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersService _answersService;
        private readonly IUsersService _usersService;
        
        public AnswersController(IUsersService usersService, IAnswersService answersService)
        {
            _usersService = usersService;
            _answersService = answersService;
        }

        [HttpPost]
        public IActionResult Create(CreateAnswersRequest request)
        {
            // StringValues userId;
            // if(!Request.Headers.TryGetValue("UserId", out userId))
            // {
            //     return Unauthorized();
            // }

            // var user = _usersService.GetById(Guid.Parse(userId));

            // if (user == null)
            // {
            //     return Unauthorized();
            // }

            // if (user.Profile == Profile.Student)
            // {
            //     return Unauthorized();
            // }

            var response = _answersService.Create(request.AnswerSheetId, request.Questions);

            // if (!response.IsValid)
            // {
            //     return BadRequest(response.Errors);
            // }
            
            return Ok(response.Id);
        }
    }
}
