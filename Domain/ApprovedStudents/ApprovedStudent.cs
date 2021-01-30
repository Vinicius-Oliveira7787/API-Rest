using System;
using System.Linq;
using Domain.Common;
using Domain.People;
using Domain.Users;

namespace Domain.ApprovedStudents
{
    public class ApprovedStudent : Person
    {
        public double Score { get; set; }

        public ApprovedStudent(double score, string name) : base(name)
        {
            Score = score;
        }       
    }
}
