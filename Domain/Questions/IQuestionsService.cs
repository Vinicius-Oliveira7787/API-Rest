
using System;

namespace Domain.Questions
{
    public interface IQuestionsService
    {
        CreatedQuestionDTO Create(Guid id ,string name);
    }
}
