using E_CommerceAPI.Application.Abstractions.Hubs;
using E_CommerceAPI.Application.Repositories;
using MediatR;
using System.Net;

namespace E_CommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductHubService _productHubService;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
           
                await _productWriteRepository.AddAsync(new()
                {

                    Name = request.Name,
                    Description = request.Description,
                    Stock = request.Stock,
                    Price = request.Price
                });
                await _productWriteRepository.SaveChanges();
               

            
            await _productHubService.ProductAddedMessageAsync($"{request.Name} ürün eklenmiştir");

            return new();
        }
    }
}
