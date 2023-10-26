using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Persistance.Contexts;
using F= E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.ProductImage
{
    public class ProductImageWriteRepository : WriteRepository<F.ProductImageFile>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
