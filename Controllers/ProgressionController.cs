namespace DeltaruneFrBackEnd.Controllers
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

        // GET api/Progression
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Progression>>> GetProgression()
        {
            IEnumerable<Progression> result = await _progressionRepository.GetProgressionAsync();

            return Ok(result);
        }

        // GET api/Progression
        [AllowAnonymous]
        [HttpGet("test")]
        public async Task<IActionResult> GetProgressionJson()
        {
            DotNetEnv.Env.Load();

            IEnumerable<Progression> result = await _progressionRepository.GetProgressionAsync();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "ProgressionJson", "Progression.json");

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
                string host = Environment.GetEnvironmentVariable("HOST");
                string user = Environment.GetEnvironmentVariable("USER");
                string mdp = Environment.GetEnvironmentVariable("MDP");

                using var client = new FtpClient(host, new System.Net.NetworkCredential { UserName = user, Password = mdp } );

                await client.ConnectAsync();

                await client.UploadFileAsync(path, "/public_html/Progression.json", FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

                await client.DisconnectAsync();

                return Ok("fini");
            }
            catch (Exception e) 
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        // PUT api/Progression
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
