using System;

namespace Domain.ApprovedStudents
{
    public interface IApprovedStudentsService
    {
        CreatedApprovedStudentDTO Create(string name, double score);
        ApprovedStudent GetById(Guid id);
    }
}
