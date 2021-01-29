using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exams;

namespace Domain.AswerExams
{
    public class AswerExamsService : IAswerExamsService {
        private AswerExam _exam { get; set; }
        public double Score { get; private set; } = 0;
        public readonly IAswerExamsRepository _AswerExamsRepository;

        public AswerExamsService(IAswerExamsRepository aswerExamsRepository)
        {
            _AswerExamsRepository = aswerExamsRepository;
        }

        public CreatedAswerExamsDTO Create(List<string> questionsAswers, Exam exam) {
            _exam = new AswerExam(questionsAswers);
            var validation = _exam.Validate();
            
            if (!validation.isValid) {
                return new CreatedAswerExamsDTO(validation.message);
            }

                var examCorrection = CorrectExam(exam);
                if (examCorrection == null) {
                    return new CreatedAswerExamsDTO(validation.message);
                }

                return new CreatedAswerExamsDTO(_exam.Id);
        }

        private double? CorrectExam(Exam exam) {
            int correctAswersCounter = 0;
            
            for (int i = 0; i < exam.Questions.Count; i++) {
                //   TeacherTemplate  /    StudentAswers
                if (exam.Questions[i] == _exam.Questions[i]) {
                    correctAswersCounter++;
                }
            }
            
            // Calculating the score
            double score = (correctAswersCounter / exam.Questions.Count) * 10;
            
            if (score > -1 && score < 11) {
                Score = score;
                return score;
            }

            return null;
        }

        public (AswerExam aswerExam, double score) GetById(Guid id) {
            var aswerExam = _AswerExamsRepository.Get(id);
            
            return (aswerExam, Score);
        }
    }
}