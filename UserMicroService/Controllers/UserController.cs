using Microsoft.AspNetCore.Mvc;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroService.Repositories.Interfaces;

namespace UserMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<User> _user;
        public UserController(IUserRepository<User> user)
        {
            _user = user;
        }


        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user.UserID > 0)
            {
                _user.Update(user);
            }
            else
            {
                _user.Insert(user);
            }
            return Ok();
        }
    }
}
