using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Domain.AnswerSheets
{
    public class AnswerSheet : Entity
    {
        public IList<string> Questions { get; set; }

        public AnswerSheet(string[] answers)
        {
            if (answers != null)
            {
                Questions = answers.ToList();
            }
        }

        public (string message, bool isValid) ValidateAanswer()
        {
            if (Questions == null)
            {
                return ("emptyAnswerSheet", false);
            }

            var emptyAanswerValidation = Questions.Any(question => question == null);
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
            if (!validateAanswer.isValid)
            {
                errors.Add(validateAanswer.message);
            }

            return (errors, errors.Count == 0);
        }
    }
}
