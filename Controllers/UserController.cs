﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaruneFrBackEnd.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTManager _jWTManager;
        private readonly ITestRepository _testRepository;

        public UserController(IJWTManager jWTManager, ITestRepository testRepository)
        {
            _jWTManager = jWTManager;
            _testRepository = testRepository;
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

        [HttpGet]
        [Route("test2")]
        public async Task<ActionResult<IEnumerable<Chapitre>>> TestSQL()
        {
            try
            {
                var test = await _testRepository.TestSQL();
                return Ok(test);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return NotFound(e.Message);
            }

        }
    }
}
