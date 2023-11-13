using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minutes);
    }
}
