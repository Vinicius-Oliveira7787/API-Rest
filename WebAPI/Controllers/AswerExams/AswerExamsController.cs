using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Domain.Users;
using System;
using Domain.Exams;
using Domain.AswerExams;

namespace WebAPI.Controllers.Exams
{
    [ApiController]
    [Route("[controller]")]
    public class AswerExamsController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IExamsService _examsService;
        private readonly IAswerExamsService _aswerExamsService;
        
        public AswerExamsController ( 
            IUsersService usersService, 
            IExamsService examsService, 
            IAswerExamsService aswerExamsService 
        )
        {
            _examsService = examsService;
            _usersService = usersService;
            _aswerExamsService = aswerExamsService;
        }

        [HttpPost]
        public IActionResult CreateExamAswers(CreateAswerExamsRequest request) {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId)) {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null) {
                return NotFound();
            }

            if (user.Profile == Profile.Teacher) {
                return Unauthorized();
            }

            var exam = _examsService.GetById(request.ExamId);

            if (exam == null)
            {
                return NotFound();
            }
            
            var response = _aswerExamsService.Create(request.QuestionsAswers, exam);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            // ToDo? auto enviar neste Ok() a nota do aluno
            var examScore = _aswerExamsService.GetById(response.Id).score;
            user.CalculateBulletinNote(examScore);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetScore(Guid id) {
            var aswerExams = _aswerExamsService.GetById(id);

            if (aswerExams.aswerExam == null)
            {
                return NotFound();
            }

            return Ok(aswerExams.score);
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
