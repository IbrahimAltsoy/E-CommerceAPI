using E_CommerceAPI.Application.DTOs.User;
using E_CommerceAPI.Domain.Entities.Identity;

namespace E_CommerceAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser createUser);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate,int addOnAccessTokenTime);
    }
}
