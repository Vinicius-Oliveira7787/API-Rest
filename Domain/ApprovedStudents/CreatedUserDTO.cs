using System;
using System.Collections.Generic;

namespace Domain.ApprovedStudents
{
    public class CreatedApprovedStudentDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedApprovedStudentDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedApprovedStudentDTO(IList<string> errors)
        {
            Errors = errors;
        }
    }
}
