using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaruneFrBackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTManager _jWTManager;

        public UserController(IJWTManager jWTManager)
        {
            _jWTManager = jWTManager;
        }

        [HttpPost]
        [Route("inscription")]
        public async Task<IActionResult> SetAccount(User userdata)
        {
            try
            {
                await _jWTManager.CreateAccount(userdata);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("connexion")]
        public ActionResult<Tokens> GetAccount(User usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet]
        [Route("test")]
        public ActionResult<string> Test()
        {
            return Ok("ok");
        }
    }
}
