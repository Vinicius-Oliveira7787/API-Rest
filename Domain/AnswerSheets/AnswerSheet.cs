using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Questions;

namespace Domain.AnswerSheets
{
    public class AnswerSheet : Entity
    {
        public string Title { get; set; }
        public virtual IList<Question> Questions { get; set; }

        public AnswerSheet(string name, IList<string> questions)
        {
            Title = name;
            if (questions != null)
            {
                Questions = questions
                    .Select(aswer => new Question(aswer))
                    .ToList();
            }
        }


        protected bool ValidateName()
        {
            if (string.IsNullOrEmpty(Title))
            {
                return false;
            }

            return true;
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

            (string message, bool isValid) validation = ("", true);
            for (int i = 0; i < Questions.Count; i++)
            {
                var temporary = Questions[i].Validate();
                if (!temporary.isValid)
                {
                    validation.message = temporary.errors.ToString();
                    validation.isValid = false;
                    break;
                }
            }

            if (!validation.isValid)
            {
                return (validation.message, false);
            }

            return ("OK", true);
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Title not found");
            }
            
            var validateAanswer = ValidateAanswer();
            if (!validateAanswer.isValid)
            {
                errors.Add(validateAanswer.message);
            }

            return (errors, errors.Count == 0);
        }
    }
}
