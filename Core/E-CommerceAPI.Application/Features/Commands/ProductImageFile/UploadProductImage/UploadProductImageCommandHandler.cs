using E_CommerceAPI.Application.Abstractions.Storage;
using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Application.Repositories;
using P= E_CommerceAPI.Domain.Entities;

using MediatR;

namespace E_CommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler :IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;

        public UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageWriteRepository productImageWriteRepository)
        {
            _storageService = storageService;
            _productReadRepository = productReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);
            P.Product product = await _productReadRepository.GetByIdAsync(request.Id, true);
            await _productImageWriteRepository.AddRangeAsync(result.Select(p => new P.ProductImageFile()
            {
                FileName = p.fileName,
                Path = p.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<P.Product>() { product }
            }).ToList());
            await _productImageWriteRepository.SaveChanges();
            return new();
        }
    }
}
