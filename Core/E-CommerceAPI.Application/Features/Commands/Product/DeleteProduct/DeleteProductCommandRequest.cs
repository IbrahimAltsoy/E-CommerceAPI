using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public string id { get; set; }
    }
}
