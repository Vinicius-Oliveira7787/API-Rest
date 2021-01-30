using System;
using System.Linq;
using Domain.AnswerSheets;
using Xunit;

namespace Tests.Domain.Questions
{
    public class AnswerSheetsTest
    {
        [Theory]
        [InlineData("Prova", new string[1]{"questão1"})]
        public void Should_return_true_when_(string name, string[] questions)
        {
            var answerSheet = new AnswerSheet(name, questions.ToList());

            var answerSheetIsValid = answerSheet.Validate();

            Assert.True(answerSheetIsValid.isValid);
            Assert.Equal("sla", answerSheetIsValid.errors[0]);
        }
    }
}