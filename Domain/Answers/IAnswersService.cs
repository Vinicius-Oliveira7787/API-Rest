using System;
using System.Collections.Generic;
using Domain.AnswerSheets;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(Guid id, string[] aswers);
        double? CorrectExam(string[] exam);
        (Answer aswerExam, double score) GetById(Guid id);
    }
}
