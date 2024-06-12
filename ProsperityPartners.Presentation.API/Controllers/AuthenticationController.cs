using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsperityPartners.Application.Features.AuthenticationFeatures.Commands;
using ProsperityPartners.Application.Features.AuthenticationFeatures.Queries;
using ProsperityPartners.Application.Shared.AuthenticationaDTOs;
using ProsperityPartners.Presentation.API.ActionFilters;

namespace ProsperityPartners.Presentation.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISender _sender;
        public AuthenticationController(ISender sender) => _sender = sender;

        [HttpPost("register")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
            var result = await _sender.Send( new RegisterUserCommand(createUserDto));
            
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            var isValidUser = await _sender.Send(new ValidateUserQuery(user));
            if (!isValidUser)
                return Unauthorized();
            // Generate UserToken
            var token = await _sender.Send(new CreateTokenCommand());
            return Ok(new { Token = token });
        }
    }
}
