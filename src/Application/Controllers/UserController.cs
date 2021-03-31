using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : DefaultController
    {
        IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.FindAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateAsync(user);
            if (result.Email != null || result.Name != null)
            {
                return Created("/users", result);
            }
            else
            {
                return BadRequest("Fail to create User");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.UpdateAsync(user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _service.DeleteAsync(id));
        }
    }
}
