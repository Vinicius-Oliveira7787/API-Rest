using System;
using System.Collections.Generic;

namespace Domain.AnswerSheets
{
    public interface IAnswerSheetsService
    {
        CreatedAnswerSheetDTO Create(List<string> questions);
        AnswerSheet GetById(Guid id);
        string[] GetQuestions(Guid id);
    }
}
