using System;
using Domain.Common;

namespace Domain.Answers
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly IRepository<Answer> _repository;

        public AnswersRepository(IRepository<Answer> repository)
        {
            _repository = repository;
        }
        public void Add(Answer team)
        {
            _repository.Add(team);
        }

        public Answer Get(Func<Answer, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public Answer Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
