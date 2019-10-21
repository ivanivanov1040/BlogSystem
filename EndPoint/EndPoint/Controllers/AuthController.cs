using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPoint.Models;
using EndPoint.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private BlogContext _dbContext;
        private UserManager<ApplicationUserModel> _userManager;
        public AuthController(BlogContext context, UserManager<ApplicationUserModel> userManager)
        {
            this._dbContext = context;
            this._userManager = userManager;
        }
        public IActionResult Login([FromBody]LoginViewModel model)
        {
            if (true)
            {

                return Ok();            
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}