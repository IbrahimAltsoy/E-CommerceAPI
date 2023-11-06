using E_CommerceAPI.Application.Repositories;
using MediatR;
using System.Net;

namespace E_CommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //if (ModelState.IsValid)
            //{

            //}
            await _productWriteRepository.AddAsync(new()
            {

                Name = request.Name,
                Description = request.Description,
                Stock = request.Stock,
                Price = request.Price
            });
            await _productWriteRepository.SaveChanges();
            return new();
        }
    }
}
