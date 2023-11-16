using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E_CommerceAPI.Application.Exceptions;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.Abstractions.Services;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUsercommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUsercommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
           var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 300);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };
        }
    }
}
