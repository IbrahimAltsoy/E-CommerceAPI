using MediatR;

namespace E_CommerceAPI.Application.Features.Queries.Product.GetByIdAsyncProduct
{
    public class GetByIdAsyncQueryRequest:IRequest<GetByIdAsyncQueryResponse>
    {
        public string id { get; set; }
    }
}
