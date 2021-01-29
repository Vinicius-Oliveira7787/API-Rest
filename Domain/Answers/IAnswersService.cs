using System.Collections.Generic;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(string name, IList<string> aswers);
    }
}
