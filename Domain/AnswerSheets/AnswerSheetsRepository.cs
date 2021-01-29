using System;
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
        public void Add(AnswerSheet team)
        {
            _repository.Add(team);
        }

        public AnswerSheet Get(Func<AnswerSheet, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public AnswerSheet Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
