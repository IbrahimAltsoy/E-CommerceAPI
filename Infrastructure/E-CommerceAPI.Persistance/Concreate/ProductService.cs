using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Concreate
{
    public class ProductService : IProductService
    {

        public List<Product> GetProducts()
        => new() { new()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            Name= "Product-1",
            Stock= 5,
            Price= 5

        },
        new()
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTime.Now,
            Name= "Product-2",
            Stock= 15,
            Price= 15

        }};
    }
}
