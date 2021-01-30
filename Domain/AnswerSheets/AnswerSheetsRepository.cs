using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.AnswerSheets
{
    public class AnswerSheetsRepository : IAnswerSheetsRepository
    {
        private readonly IRepository<AnswerSheet> _repository;

        public AnswerSheetsRepository(IRepository<AnswerSheet> repository)
        {
            _repository = repository;
        }
        
        public void Add(AnswerSheet answerSheet)
        {
            _repository.Add(answerSheet);
        }

        public AnswerSheet Get(Func<AnswerSheet, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public AnswerSheet Get(Guid id)
        {
            return _repository.Get(id);
        }

        public List<AnswerSheet> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
