using E_CommerceAPI.Application.Features.Commands.AppUser.GoogleLogin;
using E_CommerceAPI.Application.Features.Commands.AppUser.LinkedinLogin;
using E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser;
using E_CommerceAPI.Application.Features.Commands.AppUser.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            // userName: Cengiz password :Samsun01.  
            LoginUsercommandResponse response = await _mediator.Send(loginUserCommandRequest);
           
            return Ok(response);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }
        [HttpPost("linkedin-login")]
        public async Task<IActionResult> FacebookLogin(LinkedinLoginCommandRequest facebookLoginCommandRequest)
        {
            LinkedinLoginCommandResponse response = await _mediator.Send(facebookLoginCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin([FromBody]RefreshTokenLoginCommandRequest refreshTokenCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenCommandRequest);
            return Ok(response);
        }
    }
}
