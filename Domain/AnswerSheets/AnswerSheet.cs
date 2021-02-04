using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Answers;
using Domain.Common;

namespace Domain.AnswerSheets
{
    public class AnswerSheet : Entity
    {
        public virtual IList<Answer> Questions { get; set; }

        public AnswerSheet(IList<string> answers)
        {
            if (answers != null)
            {
                Questions = answers
                    .Select(playerName => new Answer(Id, playerName))
                    .ToList();
            }
        }

        protected AnswerSheet() {}

        private (string message, bool isValid) ValidateAanswer()
        {
            if (Questions == null || Questions.Count == 0)
            {
                return ("empty AnswerSheet", false);
            }
            
            var emptyAanswerValidation = false;
            for (int i = 0; i < Questions.Count; i++)
            {
                var temporary = String.IsNullOrEmpty(Questions[i].Question);
                if (temporary || Questions[i].Question == " ")
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
