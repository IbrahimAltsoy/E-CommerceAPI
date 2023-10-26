using E_CommerceAPI.Application.Repositories.InvoiceFile;
using E_CommerceAPI.Persistance.Contexts;
using F = E_CommerceAPI.Domain.Entities;
namespace E_CommerceAPI.Persistance.Repositories.InvoiceFile
{
    public class InvoiceFileWriteRepository : WriteRepository<F.InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
