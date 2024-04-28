using Labb3_AvanceradDotNet.Services;
using Labb3Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Labb3_AvanceradDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private ILabb3<Interest> _labb;
        public InterestController(ILabb3<Interest> labb)
        {
            _labb = labb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _labb.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Interest>> GetInterstById(int id)
        {
            try
            {
                var result = await _labb.GetById(id);
                if (result == null)
                {
                    return NotFound($"Interest with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _labb.Add(newInterest);
                return CreatedAtAction(nameof(GetInterstById), new { id = createdInterest.InterestId}, createdInterest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest interest)
        {
            try
            {
                if (id != interest.InterestId)
                {
                    return BadRequest($"ID {id} does not match InterestId: {interest.InterestId}");
                }
                var interestToUpdate = await _labb.GetById(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Interest with ID {id} could not be found in database");
                }
                return await _labb.Update(interest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var interestToDelete = await _labb.GetById(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Interest with ID {id} could not be found in database");
                }
                return await _labb.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
