﻿using System;
using System.Collections.Generic;
using Domain.AnswerSheets;

namespace Domain.Answers
{
    public class AnswersService : IAnswersService
    {
        private readonly IAnswersRepository _answersRepository;
        private Answer _answer { get; set; }
        private double _score { get; set; }

        public AnswersService(IAnswersRepository answersRepository)
        {
            _answersRepository = answersRepository;
        }

        public CreatedAnswerDTO Create(Guid answerSheetId, string questions)
        {
            var _answer = new Answer(answerSheetId, questions);
            var AnswerValidation = _answer.Validate();

            if (AnswerValidation.isValid)
            {
                _answersRepository.Add(_answer);
                return new CreatedAnswerDTO(_answer.Id);
            }

            return new CreatedAnswerDTO(AnswerValidation.errors);
        }

        public double? CorrectExam(List<string> exam) 
        {
            int correctAswersCounter = 0;
            
            for (int i = 0; i < exam.Count; i++) 
            {
                //   TeacherTemplate  /    StudentAswers
                if (exam[i] == _answer.Question) 
                {
                    correctAswersCounter++;
                }
            }
            
            // Calculating the score
            double score = (correctAswersCounter / exam.Count) * 10;
            
            if (score > -1 && score < 11) 
            {
                _score = score;
                return score;
            }

            return null;
        }

        public (Answer aswerExam, double score) GetById(Guid id) 
        {
            var aswerExam = _answersRepository.Get(id);
            
            return (aswerExam, aswerExam.Score = _score);
        }

        public List<Answer> GetAll() 
        {
            return _answersRepository.GetAll();
        }
    }
}
