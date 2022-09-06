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
            var users = await _service.GetAll();
            return Ok(users);
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult> FindUserById([FromRoute] Guid id)
        {
            var response = await _service.FindById(id);
            return Ok(response);
        }

        [HttpGet("Email/{email}")]
        public async Task<ActionResult> FindUserByEmail([FromRoute] string email)
        {
            var response = await _service.FindByEmail(email);
            return Ok(response);
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult> FindUserByName([FromRoute] string name)
        {
            var response = await _service.FindByName(name);
            return Ok(response);
        }

        [HttpPost("/CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _user.CreateUserAsync(request);
            return Ok(response);
        }

        [HttpPut("/UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var response = await _user.UpdateUserAsync(request);
            return Ok(response);
        }

        [HttpDelete("/DeleteUser/{Id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserRequest request)
        {
            await _user.DeleteUserAsync(request);
            return Ok();
        }
    }
}