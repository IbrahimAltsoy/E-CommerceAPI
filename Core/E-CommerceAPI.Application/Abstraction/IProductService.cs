using E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Application.Abstraction
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
