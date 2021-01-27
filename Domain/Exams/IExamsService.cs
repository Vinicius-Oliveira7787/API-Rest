using System;
using System.Collections.Generic;

namespace Domain.Exams
{
    public interface IExamsService  {
        Exam GetById(Guid id);
        CreatedExamsDTO Create(List<string> questions);
    }
}