using System;
using System.Collections.Generic;
using Domain.Answers;

namespace Domain.AnswerSheets
{
    public interface IAnswerSheetsService
    {
        CreatedAnswerSheetDTO Create(List<string> questions);
        AnswerSheet GetById(Guid id);
        List<string> GetQuestions(Guid id);
    }
}
