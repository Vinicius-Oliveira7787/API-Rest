using System;
using System.Collections.Generic;

namespace Domain.AswerExams {
    public class CreatedAswerExamsDTO {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }

        public CreatedAswerExamsDTO(Guid id) {
            Id = id;
            IsValid = true;
        }

        public CreatedAswerExamsDTO(IList<string> errors) {
            Errors = errors;
        }
    }
}
