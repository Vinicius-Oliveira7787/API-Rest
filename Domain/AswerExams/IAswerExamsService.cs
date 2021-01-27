using System;
using System.Collections.Generic;
using Domain.Exams;

namespace Domain.AswerExams
{
    public interface IAswerExamsService  {
        CreatedAswerExamsDTO Create(List<string> questionsAswers, Exam exam);
        (AswerExam aswerExam, double? score) GetById(Guid id);
    }
}