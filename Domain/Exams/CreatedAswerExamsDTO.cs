using System;
using System.Collections.Generic;

namespace Domain.Exams {
    public class CreatedExamsDTO {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedExamsDTO(Guid id) {
            Id = id;
            IsValid = true;
        }

        public CreatedExamsDTO(IList<string> errors) {
            Errors = errors;
        }
    }
}
