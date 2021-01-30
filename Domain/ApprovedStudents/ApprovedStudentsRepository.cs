using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.ApprovedStudents
{
    public class ApprovedStudentsRepository : IApprovedStudentsRepository
    {
        private readonly IRepository<ApprovedStudent> _repository;

        public ApprovedStudentsRepository(IRepository<ApprovedStudent> repository)
        {
            _repository = repository;
        }

        public void Add(ApprovedStudent user)
        {
            _repository.Add(user);
        }

        public ApprovedStudent Get(Func<ApprovedStudent, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public ApprovedStudent Get(Guid id)
        {
            return _repository.Get(id);
        }

        public List<ApprovedStudent> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
