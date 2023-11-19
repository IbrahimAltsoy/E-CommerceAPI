using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.Abstractions.Token;
using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Application.Exceptions;
using E_CommerceAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Persistance.Services
{
    public class AuthService : IAuthService
    {
        readonly HttpClient _httpClient;
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;
        


        public AuthService(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
    
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["Google:PROVIDER_ID"] }
            };
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");


            AppUser? user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new AppUser()
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
                Token token = _tokenHandler.CreateAccessToken(15,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5);
                return token;

            }
            else
            {
                throw new Exception("Invalid external authacation.");
            }
            

            
        }

        public async Task<Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime)
        {

            
            AppUser? user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                throw new NotFoundUserExceptions();
          SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5);
                return token;

            }
            else throw new AuthenticationErrorExceptions();
            //else return new LoginUserUnSuccessCommandResponse { Message = "Kimlik doğrulama hatası oluştu. Tekrardan Giriş yapınız." };
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate>DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15,user);
               await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5);
                return token;
            }
            else
                throw new NotFoundUserExceptions();


        }
    }
}
