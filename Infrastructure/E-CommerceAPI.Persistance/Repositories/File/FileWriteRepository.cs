using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Contexts;

namespace E_CommerceAPI.Persistance.Repositories.File
{
    public class FileWriteRepository : WriteRepository<Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
