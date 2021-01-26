using System;
using Domain.Common;

namespace Domain.Students
{
    public class StudentRepository : IStudentsRepository
    {
        private readonly IRepository<Student> _repository;
        public StudentRepository(IRepository<Student> repository) 
        {
            _repository = repository;
        }

        public void Add(Student student)
        {
            _repository.Add(student);
        }

        public Student Get(Func<Student, bool> predicate) {
            return _repository.Get(predicate);
        }

        public Student Get(Guid id) {
            return _repository.Get(id);
        }
    }
}
