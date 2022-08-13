namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api/Voix")]
    [ApiController]
    public class VoixController : ControllerBase
    {

        private readonly IVoixRepository _voixRepository;

        public VoixController(IVoixRepository voixRepository)
        {
            _voixRepository = voixRepository;
        }

        [HttpGet("Angular")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllVoix()
        {
            var result = await _voixRepository.GetAllVoixAsync();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetVoix()
        {
            var result = await _voixRepository.GetVoix();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetVoixById(int id)
        {
            var result = await _voixRepository.GetVoixById(id);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Chapitre/{id}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetVoixByChapter(int id)
        {
            var result = await _voixRepository.GetVoixByChapter(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SetVoix(Staff Voix)
        {
            try
            {
                await _voixRepository.SetVoix(Voix);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditVoix(Staff Voix)
        {
            try
            {
                await _voixRepository.EditVoix(Voix);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteVoix(int id)
        {
            try
            {
                await _voixRepository.DeleteVoix(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
