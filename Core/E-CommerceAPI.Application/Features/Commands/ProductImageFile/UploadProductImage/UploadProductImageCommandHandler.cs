using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler :IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        public Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
