using Microsoft.AspNetCore.Mvc;
using MediatR;
using APIEstudos.Domain.Commands;
using APIEstudos.Domain.Queries;

namespace APIEstudos.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult> FindUserById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Email/{email}")]
        public async Task<ActionResult> FindUserByEmail([FromRoute] string email)
        {
            var query = new GetUserByEmailQuery(email);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("Name/{name}")]
        public async Task<ActionResult> FindUserByName([FromRoute] string name)
        {
            var query = new GetUserByNameQuery(name);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("/CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("/UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);

            //return entity not altered!! bug
        }

        [HttpDelete("/DeleteUser/{Id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] DeleteUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}