using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.RequestParameters;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(true).Skip(request.Size * request.Page).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Description,
                p.Stock,
                p.Price


            }).ToList();
            return new()
            {
                Products = products,
                TotalCount = totalCount
            };
        }
    }
}
