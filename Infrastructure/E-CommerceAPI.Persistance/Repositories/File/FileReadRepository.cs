using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Contexts;

namespace E_CommerceAPI.Persistance.Repositories.File
{
    public class FileReadRepository : ReadRepository<Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
