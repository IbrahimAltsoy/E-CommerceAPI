using U=E_CommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E_CommerceAPI.Application.Exceptions;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<U.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<U.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
           IdentityResult result = await _userManager.CreateAsync(new()
            {
               Id= Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname, 
                UserName = request.UserName,
                Email = request.Email
                


            },request.Password);
            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded};

            if (result.Succeeded)
                response.Message = "Kullanıcı başarılı bir şekilde kayıt edilmiştir.";
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Description}- {error.Code}<br>";
                }
            }
                


          return response;
           
             
           
            
            
        }
    }
}
