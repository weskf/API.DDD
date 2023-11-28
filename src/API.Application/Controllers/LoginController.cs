using API.Domain.DTOs;
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

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (login == null)
                return BadRequest();

            try
            {
                var result = await _service.FindByLogin(login);
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
