using System.Collections.Generic;

namespace WebAPI.Controllers.AnswerSheets
{
    public class CreateAnswerSheetRequest
    {
        public List<string> Questions { get; set; }
    }
}