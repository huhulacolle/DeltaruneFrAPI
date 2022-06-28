using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaruneFrBackEnd.Controllers
{
    [Authorize]
    [Route("api/Staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        // GET api/Staff/Angular
        [HttpGet("Angular")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetAllStaff()
        {
            IEnumerable<Staff> result = await _staffRepository.GetAllStaff();

            return Ok(result);
        }

        // GET api/Staff/
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            IEnumerable<Staff> result = await _staffRepository.GetStaff();

            return Ok(result);
        }

        // GET api/Staff/:id
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffByID(int id)
        {
            IEnumerable<Staff> result = await _staffRepository.GetStaffById(id);

            return Ok(result);
        }

        // POST api/Staff/
        [HttpPost]
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

        // DELETE api/Staff
        [HttpDelete]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            try
            {
                await _staffRepository.DeleteStaff(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        // GET api/Chapitre/
        [HttpGet("Chapitre")]
        public async Task<ActionResult<IEnumerable<Chapitre>>> GetChapitres()
        {
            IEnumerable<Chapitre> result = await _staffRepository.GetChapitres();

            return Ok(result);
        }


    }
}
