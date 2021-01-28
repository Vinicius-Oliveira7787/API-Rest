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
        public Profile Profile { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public double BulletinNote { get; private set; }
        private List<double> _examsScore { get; set; }

        public User(string name, string password, string email, Profile profile) : base(name)
        {
            Password = password;
            Email = email;
            Profile = profile;
        }

        public void CalculateBulletinNote(double score) {
            var validation = ValidateExam(score);

            if (validation)
            {
                _examsScore.Add(score);
                var calculateBulletinNote = _examsScore.Sum() / _examsScore.Count;
                BulletinNote = calculateBulletinNote;
            }
        }

        private bool ValidateExam(double score) {
            if (Profile == Profile.Teacher)
            {
                return false;
            }

            if (score < 0 || score > 10)
            {
                return false;
            }

            return true;
        }
        
        private bool ValidateEmail() {
            return Regex.IsMatch(
                Email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );
        }

        public (IList<string> errors, bool isValid) Validate() {
            var errors = new List<string>();
            if (!ValidateName()) {
                errors.Add("Nome inválido.");
            }

            if (!ValidateEmail()) {
                errors.Add("Email inválido.");
            }

            return (errors, errors.Count == 0);
        }
    }
}