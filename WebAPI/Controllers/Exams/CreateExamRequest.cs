using System.Collections.Generic;

namespace WebAPI.Controllers.Exams {
    public class CreateExamRequest {
        public List<string> Questions { get; set; }
    }
}