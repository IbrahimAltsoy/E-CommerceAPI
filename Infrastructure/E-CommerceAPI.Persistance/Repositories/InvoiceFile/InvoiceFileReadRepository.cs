using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Application.Repositories.InvoiceFile;
using E_CommerceAPI.Persistance.Contexts;
using F= E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.InvoiceFile
{
    public class InvoiceFileReadRepository : ReadRepository<F.InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
