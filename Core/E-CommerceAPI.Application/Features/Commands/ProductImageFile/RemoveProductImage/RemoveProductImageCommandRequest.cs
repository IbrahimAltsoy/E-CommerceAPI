using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandRequest:IRequest<RemoveProductImageCommandResponse>
    {
        public string id { get; set; }
        public string? imageId { get; set; }
    }
}
