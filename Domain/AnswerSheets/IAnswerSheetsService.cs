using System;
using System.Collections.Generic;

namespace Domain.AnswerSheets
{
    public interface IAnswerSheetsService
    {
        CreatedAnswerSheetDTO Create(string[] questions);
        AnswerSheet GetById(Guid id);
        string[] GetQuestions(Guid id);
    }
}
