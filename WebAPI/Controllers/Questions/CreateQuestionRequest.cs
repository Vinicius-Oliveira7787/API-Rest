using System;

namespace WebAPI.Controllers.Questions
{
    public class CreateQuestionRequest
    {
        public string Name { get; set; }
        public Guid AnswerSheetId { get; set; }
    }
}