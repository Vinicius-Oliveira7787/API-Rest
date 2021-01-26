using System;
using System.Collections.Generic;

namespace Domain.Students
{
    public class CreatedStudentDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedStudentDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedStudentDTO(IList<string> errors)
        {
            // esta atribuição não é necessária pois isValid é false por padrão
            IsValid = false;
            Errors = errors;
        }
    }
}
