using System;
using Domain.Questions;
using Xunit;

namespace Tests.Domain.Questions
{
    public class QuestionsTest
    {
        [Theory]
        [InlineData(new string[1]{"Resposta inválida, somente números ou letras."}, false)]
        [InlineData(new string[1]{"OK"}, true)]
        public void Should_return_true_when_(string[] errors, bool isValid)
        {
            var question = new Question("sadas");

            var questionIsValid = question.Validate().isValid;

            Assert.True(questionIsValid);
        }
    }
}