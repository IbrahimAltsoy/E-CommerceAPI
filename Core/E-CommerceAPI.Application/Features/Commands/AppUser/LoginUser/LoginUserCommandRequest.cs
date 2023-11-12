using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest:IRequest<LoginUsercommandResponse>
    {
        public string UsernameOrEmail {  get; set; }
        public string Password {  get; set; }
    }
}
