using isp.platformb2b.models.DTOs;
using isp.platformb2b.models.entities;
using isp.platformb2b.models.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace isp.platformb2b.web.Controllers
{


    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserLoginDTO userParam)
        {
            var user = _userService.Authenticate(userParam);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("GetNavBarByRoles")]
        public ActionResult GetNavBarByRoles()
        {
            var sid = User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();
                var temp=_userService.GetNavBarByRoles(sid);
            return Ok(temp);
        }
    }
}