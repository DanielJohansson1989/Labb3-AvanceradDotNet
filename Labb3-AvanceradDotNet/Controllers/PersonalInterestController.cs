using Labb3_AvanceradDotNet.Services;
using Labb3Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Labb3_AvanceradDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInterestController : ControllerBase
    {
        private ILabb3<PersonalInterest> _labb;
        public PersonalInterestController(ILabb3<PersonalInterest> labb)
        {
            _labb = labb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonsAndInterests()
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
        public async Task<ActionResult<PersonalInterest>> GetSinglePersonWithInterests(int id)
        {
            try
            {
                var result = await _labb.GetById(id);
                if (result == null)
                {
                    return NotFound($"PersonalInterest with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonalInterest>> CreatePersonalInterest(PersonalInterest newEntity)
        {
            try
            {
                if (newEntity == null)
                {
                    return BadRequest();
                }
                var createdEntity = await _labb.Add(newEntity);
                return CreatedAtAction(nameof(GetSinglePersonWithInterests), new { id = createdEntity.PersonalInterestId }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PersonalInterest>> UpdatePersonalInterest(int id, PersonalInterest entity)
        {
            try
            {
                if (id != entity.PersonalInterestId)
                {
                    return BadRequest($"ID {id} does not match PersonalInterestId: {entity.PersonalInterestId}");
                }
                var entityToUpdte = await _labb.GetById(id);
                if (entityToUpdte == null)
                {
                    return NotFound($"PersonalInterest with ID {id} could not be found in database");
                }
                return await _labb.Update(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PersonalInterest>> DeletePersonalInterest(int id)
        {
            try
            {
                var entityToDelete = await _labb.GetById(id);
                if (entityToDelete == null)
                {
                    return NotFound($"PersonalInterest with ID {id} could not be found in database");
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
