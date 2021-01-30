using System;
using System.Linq;
using Domain.Common;
using Domain.Users;

namespace Domain.People
{
    public class ApprovedStudent : Entity
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        private readonly IUsersRepository _usersRepository;

        public ApprovedStudent(Guid userId, string name, IUsersRepository usersRepository)
        {
            UserId = userId;
            Name = name;
            _usersRepository = usersRepository;
        }       

        public User Get()
        {
            return _usersRepository.Get(UserId);
        }
    }
}
