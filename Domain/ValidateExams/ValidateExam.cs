using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Common;

namespace Domain.ValidateExams {
    public class ValidateExam : Entity {
        public List<string> Questions { get; private set; }

        protected ValidateExam(List<string> questions)
        {
            Questions = questions;
        }

        protected (IList<string> message, bool isValid) ValidateTest() {
            var message = new List<string>();
            foreach (var item in Questions)
            {
                var regexLetters = Regex
                    .IsMatch(item.Normalize(NormalizationForm.FormD), @"^([a-zA-Z]\p{M}*)+$");
                var regexNumbers = Regex.IsMatch(item, @"^\d+$");

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