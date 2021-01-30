using System;
using System.Linq;
using Domain.Answers;
using Domain.AnswerSheets;
using Domain.Users;
using Xunit;

namespace Tests.Domain.Answers
{
    public class AnswersTests
    {

        public AnswerSheet AnswerSheet()
        {
            var questions = new string[3]{"first","second","third"};
            return new AnswerSheet(questions);
        }

        [Theory]
        [InlineData("Prova", new string[1]{"questão1"})]
        public void Should_return_true_when_asxf(string name, string[] questions)
        {

            // var response = _answersService.Create(AnswerSheet().Id, questions.ToList());

            // Assert.True(response.IsValid);
            // Assert.Equal("sla", response.Errors[0]);
        }
    }
}