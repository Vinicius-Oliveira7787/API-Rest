using System;
using Domain.Common;

namespace Domain.Exams {
    public class ExamsRepository : IExamsRepository {
      
        public readonly IRepository<Exam> _repository;
        public ExamsRepository(IRepository<Exam> repository) {
            _repository = repository;
        }

        public void Add(Exam exam) {
            _repository.Add(exam);
        }

        public Exam Get(Func<Exam, bool> predicate) {
            return _repository.Get(predicate);
        }

        public Exam Get(Guid id) {
            return _repository.Get(id);
        }
    }
}