using E_CommerceAPI.Application.Repositories;
using P= E_CommerceAPI.Domain.Entities;
using MediatR;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetByIdAsyncProduct
{
    public class GetByIdAsyncQueryHandler : IRequestHandler<GetByIdAsyncQueryRequest, GetByIdAsyncQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetByIdAsyncQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdAsyncQueryResponse> Handle(GetByIdAsyncQueryRequest request, CancellationToken cancellationToken)
        {
            P.Product product= await _productReadRepository.GetByIdAsync(request.id, false);
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
            
        }
    }
}
