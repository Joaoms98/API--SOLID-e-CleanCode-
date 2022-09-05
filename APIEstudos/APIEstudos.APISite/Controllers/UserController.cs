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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var users = await _service.GetAll();
                return Ok(users);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult> FindUserById([FromRoute] Guid id)
        {
            try
            {
                var response = await _service.FindById(id);
                return Ok(response);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("Email/{email}")]
        public async Task<ActionResult> FindUserByEmail([FromRoute] string email)
        {
            var response = await _service.FindByEmail(email);
            return Ok(response);
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

        [HttpPut("/UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            try
            {
                var response = await _user.UpdateUserAsync(request);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("/DeleteUser/{Id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserRequest request)
        {
            try
            {
                await _user.DeleteUserAsync(request);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}