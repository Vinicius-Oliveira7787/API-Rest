using System.Collections.Generic;
using Domain.Common;

namespace Domain.AswerExams
{
    public class AswerExam : Entity
    {
        public List<string> Aswers { get; set; } = new List<string>();

        public AswerExam(List<string> aswers) {
            Aswers = aswers;
        }
    }
}