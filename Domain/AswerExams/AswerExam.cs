using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Domain.Questions;
using Domain.ValidateExams;

namespace Domain.AswerExams
{
    public class AswerExam : ValidateExam {
        public virtual IList<Question> Questions { get; set; }
        
        public AswerExam(IList<string> questions) {
            if (questions != null) {
                Questions = questions
                    .Select(question => new Question(Id, question))
                    .ToList();
            }
        }

        protected AswerExam() {}

        public AswerExam(List<string> questions){}

            public (IList<string> message, bool isValid) Validate() {
            var validation = ValidateTest(Questions);
            
            if (!validation.isValid) {
                return (validation.message, validation.isValid);
            }

            return (validation.message, validation.isValid);
        }
    }
}