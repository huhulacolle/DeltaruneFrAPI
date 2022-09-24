using Microsoft.AspNetCore.Mvc;

namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _jWTManager;

        public UserController(IUserRepository jWTManager)
        {
            _jWTManager = jWTManager;
        }

        [HttpPost]
        [Route("inscription")]
        public async Task<IActionResult> SetAccount(User userdata)
        {
            Request.Headers.TryGetValue("Authorization", out var BearerToken);

            string token = BearerToken.ToString().Split("Bearer")[1].Remove(0, 1);

            string name = new JwtSecurityTokenHandler().ReadJwtToken(token).Payload.Claims.AsList()[0].Value;

            if (name.ToLower() != "admin")
            {
                return Unauthorized();
            }

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

        [AllowAnonymous]
        [HttpPost]
        [Route("connexion")]
        public ActionResult<string> GetAccount(User usersdata)
        {
            string token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
