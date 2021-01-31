using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Domain.People;

namespace Domain.Users
{
    public class User : Person
    {
        public Profile Profile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public double? Score { get; private set; }
        private List<double> _allScores { get; set; } = new List<double>();

        public User(string name, string password, string email, Profile profile) : base(name)
        {
            Password = password;
            Email = email;
            Profile = profile;
        }

        public bool SetScore(double score)
        {
            if (score > -1 && score < 11)
            {
                _allScores.Add(score);
                return true;
            }

            return false;
        }

        public double GetScore()
        {
            double temporay = 0;
            
            temporay = _allScores.Sum() / _allScores.Count;
            Score = temporay;

            return temporay;
        }

        private bool ValidateEmail()
        {
            return Regex.IsMatch(
                Email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );
        }

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }

            if (!ValidateEmail())
            {
                errors.Add("Email inválido.");
            }

            return (errors, errors.Count == 0);
        }
    }
}