using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Answers;
using Domain.AnswerSheets;
using Domain.Common;

namespace Domain.Questions
{
    public class Question : Entity
    {
        public string Aswer { get; private set; }
        public Guid AnswerSheetId { get; set; }
        public virtual AnswerSheet AnswerSheet { get; set; }

        public Question(Guid answerSheetId ,string aswer)
        {
            AnswerSheetId = answerSheetId;
            Aswer = aswer;
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            // var validation = ValidateAswer();
            
            // if (!validation.isValid)
            // {
            //     errors.Add($"{validation.message}");
            // }

            return (errors, errors.Count == 0);
        }

        private (string message, bool isValid) ValidateAswer()
        {
            // var regexLetters = Regex
            //     .IsMatch(Aswer.Normalize(NormalizationForm.FormD), @"^([a-zA-Z]\p{M}*)+$");
            // var regexNumbers = Regex.IsMatch(Aswer, @"^\d+$");

            // if (!regexLetters && !regexNumbers)
            // {
            //     return ("Resposta inválida, somente números ou letras.", false);
            // }
            
            return ("OK", true);
        }
    }
}
