using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Auth;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly UserManager<U.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;


        public GoogleLoginCommandHandler(UserManager<U.AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "452756695338-an9ehvm7aotc1dhvrrflpqrmehbeqqj0.apps.googleusercontent.com" }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, settings);
            var info = new UserLoginInfo(request.Provider, payload.Subject,request.Provider);


            U.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            bool result = user != null;
            if (user==null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user==null)
                {
                    user = new U.AppUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name
                    };
                    var identiyResult = await _userManager.CreateAsync(user);
                    result = identiyResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);

            }
            else
            {
                throw new Exception("Invalid external authacation.");
            }
            Token token = _tokenHandler.CreateAccessToken(1);
            return new()
            {
                Token = token

            };
        }
    }
}
