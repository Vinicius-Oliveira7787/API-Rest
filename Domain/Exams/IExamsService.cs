using System.Collections.Generic;

namespace Domain.Exams
{
    public interface IExamsService  {
        bool AnswerQuestions(List<string> aswers);

        int CheckCorrectAswers() ;
    }
}