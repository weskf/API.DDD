using API.Domain.Entidades;
using API.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Application.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;
        public LoginController(ILoginService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (user == null)
                return BadRequest();

            try
            {
                var result = await _service.FindByLogin(user);
                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
