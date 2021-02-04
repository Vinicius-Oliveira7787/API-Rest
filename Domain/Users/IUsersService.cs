using System;
using System.Collections.Generic;

namespace Domain.Users
{
    public interface IUsersService
    {
        CreatedUserDTO Create(
            string name,
            Profile profile,
            string email,
            string password
        );

        User GetById(Guid id);
        
        List<User> GetAll();
    }
}
