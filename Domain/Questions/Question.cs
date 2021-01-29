using System;
using System.Collections.Generic;
using System.Linq;
using Domain.AnswerSheets;
using Domain.Common;

namespace Domain.Questions
{
    public class Question : Entity
    {
        public double Score { get; private set; }
        public virtual AnswerSheet Team { get; private set; }
        public Guid AswerSheetId { get; private set; }
        public string Aswer { get; private set; }

        public Question(Guid aswerSheetId, string aswer)
        {
            AswerSheetId = aswerSheetId;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateAswer())
            {
                errors.Add("resposta inválida.");
            }
            return (errors, errors.Count == 0);
        }

        private bool ValidateAswer()
        {
            if (string.IsNullOrEmpty(Aswer))
            {
                return false;
            }

            var words = Aswer.Split(' ');
            if (words.Length < 2)
            {
                return false;
            }

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
    }
}
