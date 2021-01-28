using System.Collections.Generic;
using Domain.Common;
using Domain.ValidateExams;

namespace Domain.AswerExams
{
    public class AswerExam : ValidateExam
    {
        public AswerExam(List<string> aswers) : base(aswers) {}

        public (IList<string> message, bool isValid) Validate() {
            var validation = ValidateTest();

            if (!validation.isValid) {
                return (validation.message, validation.isValid);
            }

            return (validation.message, validation.isValid);
        }
    }
}