using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Answers;
using Domain.AnswerSheets;
using Xunit;

namespace Tests.Domain.Answers
{
    public class AnswersTests
    {

        private AnswerSheet GetAnswerSheet()
        {
            var questions = new List<string>{"first","second","third"};
            return new AnswerSheet(questions);
        }

        private Answer CreateAnswer(string content)
        {
            return new Answer(GetAnswerSheet().Id, content);
        }

        [Theory]
        [InlineData("OK", true)]
        public void Should_return_true_when_passed_correct_Answer(string message, bool validation)
        {
            // Dado / Setup
            var questions = "first";
            var answer = CreateAnswer(questions);
            
            // Quando / Ação
            var response = answer.Validate();
            
            // Deve / Asserções
            Assert.True(response.isValid);
        }

        [Theory]
        [InlineData(false, "")]
        [InlineData(false, null)]
        public void Should_return_false_when_passed_empty_Answer(bool validation, string content)
        {
            // Dado / Setup
            var answerSheet = CreateAnswer(content);

            // Quando / Ação
            var response = answerSheet.Validate();

            // Deve / Asserções
            Assert.False(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"OK"}, "sla")]
        [InlineData(new string[1]{"OK"}, "1")]
        public void Should_return_OK_when_passed_correct_Answer(string[] errors, string content)
        {
            // Dado / Setup
            var answerSheet = CreateAnswer(content);

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            // Assert.Equal(errors, response.errors.ToArray());
            Assert.True(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"Missing Question(s)"}, " ")]
        [InlineData(new string[1]{"empty Answer"}, "")]
        public void Should_return_Missing_Question_when_incorrect_question_in_Answer(
            string[] errors, string content
        )
        {
            // Dado / Setup
            var answerSheet = CreateAnswer(content);

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
            Assert.False(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"empty Answer"}, null)]
        public void Should_return__when_Answer_is_null(string[] errors, string content)
        {
            // Dado / Setup
            var answer = CreateAnswer(content);

            // Quando / Ação
            var response = answer.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
            Assert.False(response.isValid);
        }
    }
}