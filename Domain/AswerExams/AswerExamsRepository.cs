using System;
using Domain.Common;

namespace Domain.AswerExams {
    public class AswerExamsRepository : IAswerExamsRepository {
      
        public readonly IRepository<AswerExam> _repository;
        public AswerExamsRepository(IRepository<AswerExam> repository) {
            _repository = repository;
        }

        public void Add(AswerExam exam) {
            _repository.Add(exam);
        }

        public AswerExam Get(Func<AswerExam, bool> predicate) {
            return _repository.Get(predicate);
        }

        public AswerExam Get(Guid id) {
            return _repository.Get(id);
        }
    }
}