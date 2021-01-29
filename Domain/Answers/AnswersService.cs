using System;
using System.Collections.Generic;
using Domain.AnswerSheets;

namespace Domain.Answers
{
    public class AnswersService : IAnswersService
    {
        private readonly IAnswersRepository _answersRepository;
        private Answer _answer { get; set; }
        private IList<string> _questions { get; set; }
        private double _score { get; set; }

        public AnswersService(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository;
        }

        public CreatedAnswerDTO Create(string name, IList<string> questions)
        {
            var _answer = new Answer(name, questions);
            var AnswerValidation = _answer.Validate();

            if (AnswerValidation.isValid)
            {
                _answersRepository.Add(_answer);
                return new CreatedAnswerDTO(_answer.Id);
            }

            return new CreatedAnswerDTO(AnswerValidation.errors);
        }

        public double? CorrectExam(AnswerSheet exam) {
            int correctAswersCounter = 0;
            
            for (int i = 0; i < exam.Questions.Count; i++) {
                //   TeacherTemplate  /    StudentAswers
                if (exam.Questions[i] == _answer.Answers[i]) {
                    correctAswersCounter++;
                }
            }
            
            // Calculating the score
            double score = (correctAswersCounter / exam.Questions.Count) * 10;
            
            if (score > -1 && score < 11) {
                _score = score;
                return score;
            }

            return null;
        }

        public (Answer aswerExam, double score) GetById(Guid id) {
            var aswerExam = _answersRepository.Get(id);
            
            return (aswerExam, aswerExam.Score = _score);
        }
    }
}
