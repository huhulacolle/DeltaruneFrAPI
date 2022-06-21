﻿using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("Chapitre")]
        public async Task<ActionResult<IEnumerable<Chapitre>>> GetChapitres()
        {
            IEnumerable<Chapitre> result = await _staffRepository.GetChapitres();

            return Ok(result);
        }


    }
}
