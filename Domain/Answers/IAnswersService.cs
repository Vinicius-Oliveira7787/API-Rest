using System;
using System.Collections.Generic;

namespace Domain.Answers
{
    public interface IAnswersService
    {
        CreatedAnswerDTO Create(Guid id, string aswers);
        double? CorrectExam(List<string> exam);
        (Answer aswerExam, double score) GetById(Guid id);
    }
}
