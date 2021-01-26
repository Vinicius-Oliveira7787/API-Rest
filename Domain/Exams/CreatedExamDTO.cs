using System;
using System.Collections.Generic;

namespace Domain.Exams {
    public class CreatedExamDTO {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedExamDTO(Guid id) {
            Id = id;
            IsValid = true;
        }

        public CreatedExamDTO(IList<string> errors) {
            Errors = errors;
        }
    }
}
