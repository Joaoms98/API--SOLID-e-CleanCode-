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

        	
            //Error: response status is 500

            //Response body
            //Download
            //System.InvalidOperationException: Unable to resolve service for type 'APIEstudos.Interfaces.IUserCommand' while attempting to activate 'APIEstudos.Controllers.UserController'.
            //   at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)
            //   at lambda_method9(Closure , IServiceProvider , Object[] )
            //   at Microsoft.AspNetCore.Mvc.Controllers.ControllerActivatorProvider.<>c__DisplayClass7_0.<CreateActivator>b__0(ControllerContext controllerContext)
            //   at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass6_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)
            //   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
            //   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
            //--- End of stack trace from previous location ---
            //   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
            //   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
            //   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
            //   at Microsoft.AspNetCore.Routing.EndpointMiddleware.<Invoke>g__AwaitRequestTask|6_0(Endpoint endpoint, Task requestTask, ILogger logger)
            //   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
            //   at Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIMiddleware.Invoke(HttpContext httpContext)
            //   at Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext, ISwaggerProvider swaggerProvider)
            //   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

            //HEADERS
            //=======
            //Accept: */*
            //Host: localhost:7032
            //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.134 Safari/537.36 OPR/89.0.4447.83
            //:method: POST
            //Accept-Encoding: gzip, deflate, br
            //Accept-Language: pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7
            //Content-Type: application/json
            //Origin: https://localhost:7032
            //Referer: https://localhost:7032/swagger/index.html
            //Content-Length: 134
            //sec-ch-ua: "Opera";v="89", "Chromium";v="103", "_Not:A-Brand";v="24"
            //sec-ch-ua-mobile: ?0
            //sec-ch-ua-platform: "Windows"
            //sec-fetch-site: same-origin
            //sec-fetch-mode: cors
            //sec-fetch-dest: empty
    }
}
