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
        [InlineData("OK", true)]
        public void Should_return_true_when_passed_correct_AnswerSheet(string message, bool validation)
        {

            var answerSheet = AnswerSheet();
            var response = answerSheet.Validate();

            Assert.True(response.isValid);
        }

        [Theory]
        [InlineData(false, new string[1]{""})]
        [InlineData(false, null)]
        public void Should_return_false_when_passed_empty_AnswerSheet(bool validation, string[] content)
        {

            var answerSheet = new AnswerSheet(content);
            var response = answerSheet.Validate();

            Assert.False(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"OK"}, new string[1]{"sla"})]
        [InlineData(new string[1]{"OK"}, new string[3]{"sla","1","1.5"})]
        public void Should_return_OK_when_passed_correct_AnswerSheet(string[] errors, string[] content)
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(content);

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
        }

        [Theory]
        [InlineData(new string[1]{"Missing Question(s)"}, new string[1]{" "})]
        [InlineData(new string[1]{"Missing Question(s)"}, new string[3]{"32","1",""})]
        public void Should_return_Missing_Question_when_incorrect_question_in_AnswerSheet(string[] errors, string[] content)
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(content);

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
        }
    }
}