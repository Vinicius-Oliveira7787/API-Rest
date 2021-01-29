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
                    .Select(aswer => new Question(Id, aswer))
                    .ToList();
            }
        }

        protected AnswerSheet() {}

        protected bool ValidateName()
        {
            if (string.IsNullOrEmpty(Title))
            {
                return false;
            }

            var words = Title.Split(' ');

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }

            return true;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            if (Questions != null)
            {
                Questions.Any(player => !player.Validate().isValid);
                errors.Add("Há jogadores inválidos");
            }
            return (errors, errors.Count == 0);
        }
    }
}
