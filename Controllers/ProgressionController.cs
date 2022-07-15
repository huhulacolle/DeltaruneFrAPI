﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
