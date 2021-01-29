using System;

namespace Domain.Questions
{
    public interface IQuestionsService
    {
        CreatedQuestionDTO Create(Guid teamId, string name);
    }
}
