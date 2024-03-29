﻿namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api/Progression")]
    [ApiController]
    public class ProgressionController : ControllerBase
    {
        private readonly IProgressionRepository _progressionRepository;

        public ProgressionController(IProgressionRepository progressionRepository)
        {
            _progressionRepository = progressionRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Progression>>> GetProgression()
        {
            var result = await _progressionRepository.GetProgressionAsync();

            return Ok(result);
        }

        [HttpGet("json")]
        public async Task<IActionResult> GetProgressionJson()
        {
            DotNetEnv.Env.Load();

            var result = await _progressionRepository.GetProgressionAsync();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "ProgressionJson", "progression.json");

            string progressionJson = JsonSerializer.Serialize(result);

            try
            {
                await System.IO.File.WriteAllTextAsync(path, progressionJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

            try
            {
                string? host = Environment.GetEnvironmentVariable("HOST");
                string? user = Environment.GetEnvironmentVariable("USER");
                string? mdp = Environment.GetEnvironmentVariable("MDP");
                string? url = Environment.GetEnvironmentVariable("URL");

                using var client = new FtpClient(host, user, mdp);

                await client.ConnectAsync();

                await client.UploadFileAsync(path, url, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

                await client.DisconnectAsync();

                return Ok();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditProgression(Progression progression)
        {
            try
            {
                await _progressionRepository.EditProgression(progression);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
