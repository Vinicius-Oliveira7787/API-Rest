using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Domain.AnswerSheets;
using System.Linq;

namespace WebAPI.Controllers.AnswerSheets
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerSheetsController : ControllerBase
    {
        private readonly IAnswerSheetsService _answerSheetsService;
        private readonly IUsersService _usersService;
        
        public AnswerSheetsController(
            IUsersService usersService, 
            IAnswerSheetsService answerSheetsService
        )
        {
            _usersService = usersService;
            _answerSheetsService = answerSheetsService;
        }

        [HttpPost]
        public IActionResult Create(CreateAnswerSheetRequest request)
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

            var response = _answerSheetsService.Create(request.Questions.ToList());

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var answerSheets = _answerSheetsService.GetAll();
            return Ok(answerSheets);
        }
    }
}
