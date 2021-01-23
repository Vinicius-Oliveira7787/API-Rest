using System;
using System.Collections.Generic;
using Domain.Classrooms;
using Domain.Common;
using Domain.Profiles;
using Domain.Students;

namespace Domain.Teachers
{
    public class Teacher : Person
    {
        public Guid TeacherId { get; set; }
        public Profile Profile { get; set; }
        public virtual IList<Student> Students { get; set; } = new List<Student>();
        public virtual IList<ClassroomTeacher> Classrooms { get; set; } = new List<ClassroomTeacher>();
        
        public Teacher(string name, string cpf) : base(name, cpf){
        }

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
