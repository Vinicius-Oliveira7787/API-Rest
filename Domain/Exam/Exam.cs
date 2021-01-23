using System.Collections.Generic;

namespace Domain.Exams
{
    public class Exam
    {
        public List<string> Questions { get; set; } = new List<string>();

        public Exam(List<string> questions)
        {
            Questions = questions;
            
        }
    }
}