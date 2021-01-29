using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Questions;

namespace WebAPI.Controllers.Questions
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;
        private readonly IUsersService _usersService;
        
        public QuestionsController(IUsersService usersService, IQuestionsService questionsService)
        {
            _usersService = usersService;
            _questionsService = questionsService;
        }

        [HttpPost]
        public IActionResult Create(CreateQuestionRequest request)
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

            var response = _questionsService.Create(request.ExamId, request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }
    }
}
