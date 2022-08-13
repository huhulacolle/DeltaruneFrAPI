namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api/Beta")]
    [ApiController]
    public class BetaController : ControllerBase
    {
        private readonly IBetaRepository betaRepository;
        public BetaController(IBetaRepository betaRepository)
        {
            this.betaRepository = betaRepository;
        }

        [HttpGet("Angular")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllBeta()
        {
            var result = await betaRepository.GetAllBetaAsync();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetBeta()
        {
            var result = await betaRepository.GetBeta();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetBetaById(int id)
        {
            var result = await betaRepository.GetBetaById(id);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Chapitre/{id}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetBetaByChapter(int id)
        {
            var result = await betaRepository.GetBetaByChapter(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SetBeta(Staff beta)
        {
            try
            {
                await betaRepository.SetBeta(beta);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditBeta(Staff beta)
        {
            try
            {
                await betaRepository.EditBeta(beta);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBeta(int id)
        {
            try
            {
                await betaRepository.DeleteBeta(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
