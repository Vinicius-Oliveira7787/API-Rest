using System.Collections.Generic;
using System.Linq;
using Domain.AnswerSheets;
using Xunit;

namespace Tests.Domain.AnswersSheet
{
    public class AnswersSheetTests
    {

        public AnswerSheet AnswerSheet()
        {
            var questions = new List<string>{"first","second","third"};
            return new AnswerSheet(questions);
        }

        [Theory]
        [InlineData("OK", true)]
        public void Should_return_true_when_passed_correct_AnswerSheet(string message, bool validation)
        {
            // Dado / Setup
            var answerSheet = AnswerSheet();
            
            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.True(response.isValid);
        }

        [Theory]
        [InlineData(false, new string[1]{""})]
        [InlineData(false, new string[0])]
        [InlineData(false, new string[1]{" "})]
        public void Should_return_false_when_passed_empty_AnswerSheet(bool validation, string[] content)
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(content.ToList());

            // Quando / Ação
            var response = answerSheet.Validate();

            // Deve / Asserções
            Assert.False(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"OK"}, new string[1]{"sla"})]
        [InlineData(new string[1]{"OK"}, new string[3]{"sla","1","1.5"})]
        public void Should_return_OK_when_passed_correct_AnswerSheet(string[] errors, string[] content)
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(content.ToList());

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
            Assert.True(response.isValid);
        }

        [Theory]
        [InlineData(new string[1]{"Missing Question(s)"}, new string[1]{" "})]
        [InlineData(new string[1]{"Missing Question(s)"}, new string[3]{"32","1",""})]
        public void Should_return_Missing_Question_when_incorrect_question_in_AnswerSheet(string[] errors, string[] content)
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(content.ToList());

            // Quando / Ação
            var response = answerSheet.Validate();
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
            Assert.False(response.isValid);
        }

        [Fact]
        public void Should_return_empty_AnswerSheet_when_Answers_is_null()
        {
            // Dado / Setup
            var answerSheet = new AnswerSheet(new List<string>());

            // Quando / Ação
            var response = answerSheet.Validate();
            var errors = new string[1]{"empty AnswerSheet"};
            
            // Deve / Asserções
            Assert.Equal(errors, response.errors.ToArray());
            Assert.False(response.isValid);
        }
    }
}