using System;
using System.Collections.Generic;
using Domain.AnswerSheets;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(Guid id, List<string> aswers);
        double? CorrectExam(AnswerSheet exam);
        (Answer aswerExam, double score) GetById(Guid id);
    }
}
