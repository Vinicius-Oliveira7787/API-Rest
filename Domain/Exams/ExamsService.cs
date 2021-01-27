using System;
using System.Collections.Generic;

namespace Domain.Exams
{
    public class ExamsService : IExamsService {
        private Exam _exam { get; set; }
        public readonly IExamsRepository _examsRepository;

        public ExamsService(IExamsRepository examRepository) {
            _examsRepository = examRepository;
        }

        public CreatedExamsDTO Create(List<string> questions) {
            _exam = new Exam(questions);
            var validation = _exam.Validate();
            
            if (validation.isValid) {
                return new CreatedExamsDTO(_exam.Id);
            }

            return new CreatedExamsDTO(validation.errors);
        }

        public Exam GetById(Guid id) {
            return _examsRepository.Get(id);
        }
    }
}