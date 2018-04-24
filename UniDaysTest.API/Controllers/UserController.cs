using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniDaysTest.API.Contracts;
using UniDaysTest.API.Models;

namespace UniDaysTest.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]UserDto dto)
        {
            return _service.SaveUser(new User(email:dto.Email, password:dto.Password));
        }
    }
}
