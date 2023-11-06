using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
