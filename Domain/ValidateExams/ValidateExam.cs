using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Questions;

namespace Domain.ValidateExams {
    public class ValidateExam : Entity {
        protected (IList<string> message, bool isValid) ValidateTest(IList<Question> questions) {
            var message = new List<string>();
            foreach (var item in questions)
            {
                var regexLetters = Regex
                    .IsMatch(item.Exercise.Normalize(NormalizationForm.FormD), @"^([a-zA-Z]\p{M}*)+$");
                var regexNumbers = Regex.IsMatch(item.Exercise, @"^\d+$");

                if (!regexLetters && !regexNumbers)
                {
                    message.Add("Resposta inválida, somente números ou letras.");
                    return (message, false);
                }
            }

            return (message, message.Count == 0);
        }
    }
}