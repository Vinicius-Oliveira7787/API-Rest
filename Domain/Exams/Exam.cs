using System.Collections.Generic;
using Domain.Common;

namespace Domain.Exams
{
    public class Exam : Entity
    {
        public List<string> Questions { get; private set; } = new List<string>();
        public List<string> Aswers { get; private set; }
        public double Score { get; private set; }

        public Exam(List<string> questions) {
            Questions = questions;
        }
    }
}