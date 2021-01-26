using System;

namespace WebAPI.Controllers.Students
{
    public class CreateStudentRequest
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
    }
}