using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Domain.Answers;
using System.Linq;
using Domain.AnswerSheets;
using System.Collections.Generic;

namespace WebAPI.Controllers.Answers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersService _answersService;
        private readonly IUsersService _usersService;
        private readonly IAnswersRepository _answersRepository;
        private readonly IAnswerSheetsRepository _answerSheetsRepository;
        private readonly IAnswerSheetsService _answerSheetsService;
        
        public AnswersController(
            IUsersService usersService, 
            IAnswersService answersService,
            IAnswerSheetsRepository answerSheetsRepository,
            IAnswerSheetsService answerSheetsService,
            IAnswersRepository answersRepository
        )
        {
            _usersService = usersService;
            _answersService = answersService;
            _answerSheetsRepository = answerSheetsRepository;
            _answerSheetsService = answerSheetsService;
            _answersRepository = answersRepository;
        }

        [HttpPost]
        public IActionResult Create(CreateAnswersRequest request)
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

            var response = _answersService.Create(request.AnswerSheetId, request.Questions);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet]
        public IActionResult Get(Guid request)
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

            // var response = _answerSheetsRepository.Get(AnswerSheet => AnswerSheet.Id == request.AnswerSheetId);
            // var response = _answerSheetsRepository.Get(request.AnswerSheetId);
            var questions = _answerSheetsService.GetQuestions(request);
            if (questions == null)
            {
                return NotFound();
            }

            var score = _answersService.CorrectExam(questions);
            return Ok(score);
        }
    }
}
