using APIEstudos.Interfaces;
using APIEstudos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEstudos.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommand _user;

        public UserController(IUserCommand user)
        {
            _user = user;
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
        //Retorno nulo. (ERROR)
        // {
        //  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        //  "name": "Julio",
        //  "email": "julio@email.com",
        //  "date": "2022-08-18T18:43:19.559Z"
        //}
        //{
        //  "id": "00000000-0000-0000-0000-000000000000",
        //  "name": null,
        //  "email": null,
        //  "date": "0001-01-01T00:00:00"
        //}

    }
}
