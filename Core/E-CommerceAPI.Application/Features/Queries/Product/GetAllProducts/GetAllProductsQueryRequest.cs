using E_CommerceAPI.Application.RequestParameters;
using MediatR;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        //public Pagination Pagination { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
    }
}
