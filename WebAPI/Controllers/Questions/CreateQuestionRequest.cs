using System;

namespace WebAPI.Controllers.Players
{
    public class CreateQuestionRequest
    {
        public Guid ExamId { get; set; }
        public string Name { get; set; }
    }
}