using System.Collections.Generic;
using Domain.Classrooms;
using Domain.Common;
using System;
using Domain.Exams;

namespace Domain.Students
{
    public class Student : Person
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();
        
        public virtual IList<ClassroomStudent> Classrooms { get; set; } = new List<ClassroomStudent>();

        public Student(string name, string cpf, string regist) : base(name, cpf)
        {
            
        }

        protected Student() : base("", "") {}

        public (List<string> errors, bool isValid) Validate()
        {
            var errs = new List<string>(); 
            
            if (!ValidateName())
            {
                errs.Add("Invalid name");
            }
            if (!ValidateCPF())
            {
                errs.Add("Invalid CPF");
            }
            return (errs, errs.Count == 0);
        }
    }
}
