using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Exams;

namespace Domain.Questions {
    public class Question : Entity {
        public string Exercise { get; private set; }
        public Guid ExamId { get; private set; }
        public virtual Exam Exam { get; private set; }

        public Question(Guid examId, string question)
        {
            ExamId = examId;
            Exercise = question;
        }
    }
}