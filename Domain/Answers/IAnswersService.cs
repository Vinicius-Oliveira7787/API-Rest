using System;
using System.Collections.Generic;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(Guid id, List<string> aswers);
    }
}
