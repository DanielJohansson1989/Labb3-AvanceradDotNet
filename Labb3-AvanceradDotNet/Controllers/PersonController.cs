using Labb3_AvanceradDotNet.Services;
using Labb3Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_AvanceradDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson _labb;
        public PersonController(IPerson labb)
        {
            _labb = labb;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
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
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            try
            {
                var result = await _labb.GetById(id);
                if (result == null)
                {
                    return NotFound($"Person with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("withInterests/{id:int}")]
        public async Task<ActionResult<Person>> GetPersonAndInterest(int id)
        {
            try
            {
                var result = await _labb.GetPersonAndInterests(id);
                if (result == null)
                {
                    return NotFound($"Person with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("withLinks/{id:int}")]
        public async Task<ActionResult<Person>> GetPersonAndLinks(int id)
        {
            try
            {
                var result = await _labb.GetPersonAndLinks(id);
                if (result == null)
                {
                    return NotFound($"Person with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreateNewPerson(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _labb.Add(newPerson);
                return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Person>> UpdatePerson(int id,  Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest($"ID {id} does not match PersonId: {person.PersonId}");
                }
                var personToUpdate = await _labb.GetById(id);
                if (personToUpdate == null)
                {
                    return NotFound($"Person with ID {id} could not be found in database");
                }
                return await _labb.Update(person);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _labb.GetById(id);
                if (personToDelete == null)
                {
                    return NotFound($"Person with ID { id} could not be found in database");
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
