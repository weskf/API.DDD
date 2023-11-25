using API.Domain.Entidades;
using API.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _service.GetAll();
                return Ok(user);

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _service.Get(id);
                return Ok(user); 
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(user);
                if (result != null)
                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);
                else
                    return BadRequest();

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();

            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _service.Delete(id);
                if (user)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
