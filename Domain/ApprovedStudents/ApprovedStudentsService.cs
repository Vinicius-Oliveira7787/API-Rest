using System;
using Domain.Common;

namespace Domain.ApprovedStudents
{
    public class ApprovedStudentsService : IApprovedStudentsService
    {
        private readonly IApprovedStudentsRepository _studentsRepository;

        public ApprovedStudentsService(IApprovedStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public CreatedApprovedStudentDTO Create(
            string name,
            double score
        )
        {            
            var student = new ApprovedStudent(score, name);
            if (student.Score > 7)
            {
                _studentsRepository.Add(student);
            }
            return new CreatedApprovedStudentDTO(student.Id);
        }
        
        public ApprovedStudent GetById(Guid id)
        {
            return _studentsRepository.Get(id);
        }
    }
}
