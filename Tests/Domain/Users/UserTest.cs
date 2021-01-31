using System;
using Domain.Users;
using Xunit;

namespace Tests.Domain.Users
{
    public class UserTest
    {
        [Theory]
        [InlineData("joao")]
        [InlineData("joao.silva")]
        [InlineData("joao.silva@")]
        [InlineData("joao.silvacom")]
        [InlineData("joao.silva.com")]
        [InlineData("joao.silva@.com")]
        [InlineData("joao.silva@com")]
        public void Should_return_false_when_email_is_invalid(string email)
        {
            // Dado / Setup
            var user = new User("João da Silva", "pass", email, Profile.Teacher);

            // Quando / Ação
            var userIsValid = user.Validate().isValid;

            // Deve / Asserções
            Assert.False(userIsValid);
        }

        [Theory]
        [InlineData("joao.silva@gmail.com")]
        [InlineData("tiago_delas@yahoo.com")]
        [InlineData("rodrigo.dourado@bol.com.br")]
        [InlineData("rodrigo789.dourado@bol.com.br")]
        public void Should_return_true_when_email_is_valid(string email)
        {
            // Dado / Setup
            var user = new User("João da Silva", "pass", email, Profile.Teacher);

            // Quando / Ação
            var userIsValid = user.Validate().isValid;

            // Deve / Asserções
            Assert.True(userIsValid);
        }
        
        [Theory]
        [InlineData(112)]
        [InlineData(11)]
        [InlineData(-1356)]
        [InlineData(-1)]
        public void Should_return_false_when_score_is_invalid(double score)
        {
            // Dado / Setup
            var user = new User("Viniccius 13 de Oliveira", "pass", "tiago_delas@yahoo.com", Profile.Teacher);

            // Quando / Ação
            var scoreIsValid = user.SetScore(score);

            // Deve / Asserções
            Assert.False(scoreIsValid);
        }        
        
        [Theory]
        [InlineData(0)]
        [InlineData(0.1)]
        [InlineData(1.7)]
        [InlineData(2)]
        [InlineData(3.33333333333333333333)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void Should_return_true_when_score_is_valid(double score)
        {
            // Dado / Setup
            var user = new User("Viniccius 13 de Oliveira", "pass", "tiago_delas@yahoo.com", Profile.Teacher);

            // Quando / Ação
            var scoreIsValid = user.SetScore(score);

            // Deve / Asserções
            Assert.True(scoreIsValid);
        }
    }
}
