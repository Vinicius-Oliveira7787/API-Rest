using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Questions;

namespace Domain.Answers
{
    public class Answer : Entity
    {
        public double Score { get; set; }
        public virtual IList<Question> Answers { get; set; }
        public Guid AnswerSheetId { get; set; }

        public Answer(Guid answerSheetId, IList<string> answer)
        {
            AnswerSheetId = answerSheetId;
            if (Answers != null)
            {
                Answers = answer
                    .Select(aswer => new Question(Id, aswer))
                    .ToList();
            }
        }


        // private (string message, bool isValid) ValidateAanswer()
        // {
        //     (string message, bool isValid) validation = ("", true);
        //     for (int i = 0; i < Answers.Count; i++)
        //     {
        //         var temporary = Answers[i].Validate();
        //         if (!temporary.isValid)
        //         {
        //             validation.message = temporary.errors.ToString();
        //             validation.isValid = false;
        //             break;
        //         }
        //     }

        //     if (!validation.isValid)
        //     {
        //         return (validation.message, false);
        //     }

        //     return ("OK", true);
        // }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            
            // var validateAanswer = ValidateAanswer();
            // if (!validateAanswer.isValid)
            // {
            //     errors.Add(validateAanswer.message);
            // }

            return (errors, errors.Count == 0);
        }
    }
}
