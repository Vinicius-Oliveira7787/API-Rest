using System;
using System.Collections.Generic;

namespace WebAPI.Controllers.Exams {
    public class CreateAswerExamsRequest {
        public List<string> QuestionsAswers { get; set; }
        public Guid ExamId { get; set; }
    }
}