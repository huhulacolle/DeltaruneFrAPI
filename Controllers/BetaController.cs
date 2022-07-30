using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<Beta>>> GetAllBeta()
        {
            IEnumerable<Beta> result = await betaRepository.GetAllBetaAsync();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beta>>> GetBeta()
        {
            IEnumerable<Beta> result = await betaRepository.GetBeta();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Beta>>> GetBetaById(int id)
        {
            IEnumerable<Beta> result = await betaRepository.GetBetaById(id);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Chapitre/{id}")]
        public async Task<ActionResult<IEnumerable<Beta>>> GetBetaByChapter(int id)
        {
            IEnumerable<Beta> result = await betaRepository.GetBetaByChapter(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SetBeta(Beta beta)
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

        // PUT api/Beta
        [HttpPut]
        public async Task<ActionResult> EditBeta(Beta beta)
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

        // DELETE api/Beta
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
