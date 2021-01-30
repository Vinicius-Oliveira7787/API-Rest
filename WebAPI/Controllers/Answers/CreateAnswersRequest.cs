using System;
using System.Collections.Generic;

namespace WebAPI.Controllers.Answers
{
    public class CreateAnswersRequest
    {
        public List<string> Questions { get; set; }
        public Guid AnswerSheetId { get; set; }
    }
}