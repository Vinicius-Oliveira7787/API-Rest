using System;

namespace Domain.Students {
    public class StudentsService {
        public readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository usersRepository) {
            _studentsRepository = usersRepository;
        }

        public CreatedStudentDTO Create(Guid teamId, string name) {
            var stundent = new Student(teamId, name);
            var stundentValidation = stundent.Validate();

            if (stundentValidation.isValid) {
                _studentsRepository.Add(stundent);
                return new CreatedStudentDTO(stundent.Id);
            }

            return new CreatedStudentDTO(stundentValidation.errors);
        }
    }
}
