using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        // GET api/Staff/
        [AllowAnonymous]
        [HttpGet("staff")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            IEnumerable<Staff> result = await _staffRepository.GetStaff();

            return Ok(result);
        }

        [HttpPost("staff")]
        public async Task<ActionResult> SetStaff(Staff staff)
        {
            try
            {
                await _staffRepository.SetStaff(staff);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/Chapitre/
        [HttpGet("Chapitre")]
        public async Task<ActionResult<IEnumerable<Chapitre>>> GetChapitres()
        {
            IEnumerable<Chapitre> result = await _staffRepository.GetChapitres();

            return Ok(result);
        }


    }
}
