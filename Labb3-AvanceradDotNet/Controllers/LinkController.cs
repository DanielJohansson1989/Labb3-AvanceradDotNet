using Labb3_AvanceradDotNet.Services;
using Labb3Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_AvanceradDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILabb3<Link> _labb;
        public LinkController(ILabb3<Link> labb)
        {
            _labb = labb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _labb.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Link>> GetLinkById(int id)
        {
            try
            {
                var result = await _labb.GetById(id);
                if (result == null)
                {
                    return NotFound($"Link with ID {id} could not be found in the database");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Link>> CreateNewLink(Link newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var createdLink = await _labb.Add(newLink);
                return CreatedAtAction(nameof(GetLinkById), new { id = createdLink.LinkId}, createdLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error sending data to the database");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Link>> UpdateLink(int id, Link link)
        {
            try
            {
                if (id != link.LinkId)
                {
                    return BadRequest($"ID {id} does not match LinkId: {link.LinkId}");
                }
                var linkToUpdate = await _labb.GetById(id);
                if (linkToUpdate == null)
                {
                    return NotFound($"Link with ID {id} could not be found in database");
                }
                return await _labb.Update(link);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error sending data to the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Link>> DeleteLink(int id)
        {
            try
            {
                var linkToDelete = await _labb.GetById(id);
                if (linkToDelete == null)
                {
                    return NotFound($"Link with ID {id} could not be found in database");
                }
                return await _labb.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when deleting data in the database");
            }
        }
    }
}
