using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            try
            {
                IEnumerable<Progression> result = await _progressionRepository.GetProgressionAsync();

                /*string path = Path.Combine(Directory.GetCurrentDirectory(), "ProgressionJson", "Progression.json");*/

                string path = Path.Combine(Directory.GetCurrentDirectory(), "ProgressionJson");

                string progressionJson = JsonSerializer.Serialize(result);

                /*System.IO.File.WriteAllText(path, progressionJson);*/

                return Ok(Directory.Exists(path));
            }
            catch (Exception e) 
            {
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
