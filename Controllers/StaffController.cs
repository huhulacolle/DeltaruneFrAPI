using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeltaruneFrBackEnd.Controllers
{
    [Route("api/BigStaff")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpGet("Angular")]
        public async Task<ActionResult<IEnumerable<StaffDR>>> GetAllStaff()
        {
            var result = await _staffRepository.GetAllStaff();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDR>>> GetStaff()
        {
            var result = await _staffRepository.GetStaff();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StaffDR>>> GetStaffById(int id)
        {
            var result = await _staffRepository.GetStaffById(id);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Chapitre/{id}")]
        public async Task<ActionResult<IEnumerable<StaffDR>>> GetStaffByChapter(int id)
        {
            var result = await _staffRepository.GetStaffByChapter(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> SetStaff(StaffDR Staff)
        {
            try
            {
                await _staffRepository.SetStaff(Staff);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> EditStaff(StaffDR Staff)
        {
            try
            {
                await _staffRepository.EditStaff(Staff);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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
    }
}
