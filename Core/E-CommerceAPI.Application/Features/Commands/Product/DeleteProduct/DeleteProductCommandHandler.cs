using E_CommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_CommerceAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var x = await _productWriteRepository.DeleteAsync(request.Id);
            await _productWriteRepository.SaveChanges();
            return new();
        }
    }
}
