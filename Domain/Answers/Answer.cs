using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Domain.Common;
using WF_Lista_DataTable;

namespace Domain.Answers
{
    public class Answer : Entity
    {        
        public double Score { get; set; }
        public string[] Answers { get; set; }
        public Guid AnswerSheetId { get; set; }

        public Answer(Guid answerSheetId, string[] answer)
        {
            AnswerSheetId = answerSheetId;
            Answers = answer;
        }


        private (string message, bool isValid) ValidateAanswer()
        {
            if (Answers == null || Answers.Length == 0)
            {
                return ("empty AnswerSheet", false);
            }
            
            var emptyAanswerValidation = false;
            for (int i = 0; i < Answers.Length; i++)
            {
                var temporary = String.IsNullOrEmpty(Answers[i]);
                if (temporary || Answers[i] == " ")
                {
                    emptyAanswerValidation = true;
                    break;
                }
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
