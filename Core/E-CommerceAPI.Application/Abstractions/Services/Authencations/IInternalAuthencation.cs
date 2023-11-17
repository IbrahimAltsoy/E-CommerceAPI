using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Abstractions.Services.Authencations
{
    public interface IInternalAuthencation
    {
        Task<DTOs.Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);

    }
}
