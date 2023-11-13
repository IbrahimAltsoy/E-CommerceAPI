using E_CommerceAPI.Application.DTOs;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUsercommandResponse
    {
        
    }
    public class LoginUserSuccessCommandResponse :LoginUsercommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserUnSuccessCommandResponse: LoginUsercommandResponse
    {
        public string Message { get; set; }
    }
}
