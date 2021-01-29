using System;
using Domain.Common;

namespace Domain.Questions
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly IRepository<Question> _repository;

        public QuestionsRepository(IRepository<Question> repository)
        {
            _repository = repository;
        }

        public void Add(Question question)
        {
            _repository.Add(question);
        }

        public Question Get(Func<Question, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public Question Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
