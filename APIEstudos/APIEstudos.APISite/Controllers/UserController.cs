using Microsoft.AspNetCore.Mvc;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Interfaces;

namespace APIEstudos.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommand _user;
        private readonly IUserServices _service;
        public UserController(IUserCommand user, IUserServices service)
        {
            _user = user;
            _service = service;
        }

        [HttpPost("/CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _user.CreateUserAsync(request);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id/{Id}")]
        public async Task<ActionResult> FindUserById([FromRoute] Guid Id)
        {
            try
            {
                var response = await _service.FindById(Id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}