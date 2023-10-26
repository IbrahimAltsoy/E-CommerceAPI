using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Persistance.Contexts;
using F= E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.ProductImage
{
    public class ProductImageReadRepository : ReadRepository<F.ProductImageFile>, IProductImageReadRepository
    {
        public ProductImageReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
