using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E_CommerceAPI.Application.Exceptions;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUsercommandResponse>
    {
        readonly UserManager<U.AppUser> _userManager;
        readonly SignInManager<U.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<U.AppUser> userManager, SignInManager<U.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUsercommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            U.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                throw new NotFoundUserExceptions();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                int a = 4;
                Token token = _tokenHandler.CreateAccessToken(1);
                int b = 4;
                return new LoginUserSuccessCommandResponse { Token = token };

            }
            else throw new AuthenticationErrorExceptions();
            //else return new LoginUserUnSuccessCommandResponse { Message = "Kimlik doğrulama hatası oluştu. Tekrardan Giriş yapınız." };

        }
    }
}
