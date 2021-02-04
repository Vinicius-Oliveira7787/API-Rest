using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain.AnswerSheets;
using Domain.Common;
using WF_Lista_DataTable;

namespace Domain.Answers
{
    public class Answer : Entity
    {        
        public double Score { get; set; }
        public string Question { get; set; }
        public Guid AnswerSheetId { get; set; }
        public virtual AnswerSheet AnswerSheet { get; set; }

        public Answer(Guid answerSheetId, string answer)
        {
            AnswerSheetId = answerSheetId;
            Question = answer;
        }

        protected Answer() {}

        private (string message, bool isValid) ValidateAanswer()
        {
            if (Question == null || Question.Length == 0)
            {
                return ("empty Answer", false);
            }
            
            var emptyAanswerValidation = false;

            var temporary = String.IsNullOrEmpty(Question);
            if (temporary || Question == " ")
            {
                emptyAanswerValidation = true;
            }

            if (emptyAanswerValidation)
            {
                return ("Missing Question(s)", false);
            }

            return ("OK", true);
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            
            var validateAanswer = ValidateAanswer();
            errors.Add(validateAanswer.message);
            
            if (!validateAanswer.isValid)
            {
                return (errors, false);    
            }

            return (errors, true);
        }
    }
}
