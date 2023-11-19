using E_CommerceAPI.Application.DTOs;
using E_CommerceAPI.Domain.Entities.Identity;

namespace E_CommerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser user);
        string CreateRefreshToken();
    }
}
