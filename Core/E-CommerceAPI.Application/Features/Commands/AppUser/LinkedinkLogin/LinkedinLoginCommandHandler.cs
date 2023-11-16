using MediatR;
using RestSharp;

namespace E_CommerceAPI.Application.Features.Commands.AppUser.LinkedinLogin
{
    public class FacebookLoginCommandHandler :IRequestHandler<LinkedinLoginCommandRequest, LinkedinLoginCommandResponse>
    {
        public Task<LinkedinLoginCommandResponse> Handle(LinkedinLoginCommandRequest request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
