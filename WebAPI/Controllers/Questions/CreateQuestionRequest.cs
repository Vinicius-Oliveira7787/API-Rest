using System;

namespace WebAPI.Controllers.Questions
{
    public class CreateQuestionRequest
    {
        public Guid ExamId { get; set; }
        public string Name { get; set; }
    }
}