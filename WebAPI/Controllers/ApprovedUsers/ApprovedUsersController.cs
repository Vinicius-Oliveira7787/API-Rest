using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Collections.Generic;
using Domain.ApprovedStudents;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class ApprovedUsersController : ControllerBase
    {
        private readonly IApprovedStudentsRepository _approvedStudentsRepository;
        
        public ApprovedUsersController(IApprovedStudentsRepository approvedStudentsRepository)
        {
            _approvedStudentsRepository = approvedStudentsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var user = _usersService.GetById(id);
            
            // if (user == null)
            // {
            //     return NotFound();
            // }

            var approvedStudents = _approvedStudentsRepository.GetAll();
            return Ok(approvedStudents);
        }
    }
}
            // var users = _usersRepository.GetAll();
            // var approved = users
            //     .Select(student => student.Score > 7 && student.Profile == Profile.Student)
            //     .ToList();
            // approved.Sort();
            // var approvedStudents = new List<User>();
            // for (int i = 0; i < approved.Count(); i++)
            // {
            //     var temporay = approved[i];
            //     approvedStudents.Add(users.FirstOrDefault(users => users.Score == approved[i]));
            // }