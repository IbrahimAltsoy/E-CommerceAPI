using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Abstractions.Services.Authencations
{
    public interface IExternalAuthencation
    {
        Task<DTOs.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
