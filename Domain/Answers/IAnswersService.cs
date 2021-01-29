using System;
using System.Collections.Generic;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(Guid answerSheetId, IList<string> aswers);
    }
}
