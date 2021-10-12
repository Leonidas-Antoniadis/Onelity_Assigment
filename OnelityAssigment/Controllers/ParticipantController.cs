using Microsoft.AspNetCore.Mvc;
using OnelityAssigment.DTO;
using OnelityAssigment.Models;
using OnelityAssigment.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnelityAssigment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : Controller
    {
        private readonly ParticipantService _service;

        public ParticipantController(ParticipantService service)
        {
            _service = service;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Participant>>> GetAll()
        {
            return Ok(await _service.All());
        }

        [HttpGet("AllByConference")]
        public async Task<ActionResult<List<Participant>>> AllByConference(int conferenceId)
        {
            if (conferenceId == default)
            {
                return BadRequest("ConferenceId cant be null or zero");
            }

            return Ok(await _service.AllByConference(conferenceId));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Participant participant)
        {
            try
            {
                await _service.Add(participant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateParticipant updateParticipant)
        {
            try
            {
                await _service.Update(updateParticipant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] int participantId)
        {
            if (participantId == default)
            {
                return BadRequest("ParticipantId cant be null or zero");
            }

            try
            {
                await _service.Delete(participantId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok();
        }
    }
}
