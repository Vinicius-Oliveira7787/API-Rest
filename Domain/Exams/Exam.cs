using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Domain.Common;
using Domain.ValidateExams;

namespace Domain.Exams
{
    public class Exam : ValidateExam
    {

        public Exam(List<string> questions) : base(questions) {}

            public (IList<string> message, bool isValid) Validate() {
            var validation = ValidateTest();
            
            if (!validation.isValid) {
                return (validation.message, validation.isValid);
            }

            return (validation.message, validation.isValid);
        }
    }
}