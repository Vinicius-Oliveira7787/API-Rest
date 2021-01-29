using System.Collections.Generic;

namespace WebAPI.Controllers.AnswerSheets
{
    public class CreateAnswerSheetRequest
    {
        public string Name { get; set; }
        public IList<string> Questions { get; set; }
    }
}