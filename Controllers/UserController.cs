using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaruneFrBackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public UserController(IJWTManagerRepository jWTManager)
        {
            _jWTManager = jWTManager;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult Authenticate(User usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
