using System;
using System.Collections.Generic;

namespace Domain.Exams
{
    public class ExamsService : IExamsService {
        private Exam _exam { get; set; }

        public CreatedExamDTO Create(List<string> questions, Guid id) {
            _exam = new Exam(questions);
            var validation = _exam.Validate();
            
            if (validation.isValid) {
                return new CreatedExamDTO(id);
            }

            return new CreatedExamDTO(validation.errors);
        }

        public bool AnswerQuestions(List<string> aswers) {            
            _exam.Aswers = aswers;
        }

        public int CheckCorrectAswers() {
            int CorrectAswersCounter = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i] == Aswers[i])
                {
                    CorrectAswersCounter++;
                }
            }
            
            
            Score = GenerateScore(CorrectAswersCounter);
            return CorrectAswersCounter;
        }

        private double GenerateScore(int correctAswersCounter) {
            int amountOfQuestions = Questions.Count;
            return correctAswersCounter / amountOfQuestions;
        }
    }
}