using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E_CommerceAPI.Application.Exceptions;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Logging;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUsercommandResponse>
    {
        readonly IAuthService _authService;
        readonly ILogger<LoginUserCommandHandler> _logger;

        public LoginUserCommandHandler(IAuthService authService, ILogger<LoginUserCommandHandler> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        public async Task<LoginUsercommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Kullanıcı Giriş yaptı");
           var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 15*60);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
