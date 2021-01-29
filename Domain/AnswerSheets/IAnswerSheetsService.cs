using System.Collections.Generic;

namespace Domain.AnswerSheets
{
    public interface IAnswerSheetsService
    {
        CreatedAnswerSheetDTO Create(string name, IList<string> questions);
    }
}
