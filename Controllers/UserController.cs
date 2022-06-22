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
        public ActionResult<Tokens> GetAccount(string nom, string mdp)
        {
            User usersdata = new()
            {
                nom = nom,
                mdp = mdp
            };

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
