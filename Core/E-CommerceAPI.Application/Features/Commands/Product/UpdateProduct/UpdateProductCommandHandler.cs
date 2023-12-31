﻿using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            E_CommerceAPI.Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id, true);
            product.Name = request.Name;
            product.Description = request.Description;
            product.Stock = request.Stock;
            product.Price = request.Price;

            await _productWriteRepository.SaveChanges();
            _logger.LogInformation("Ürün Güncellendi");
            return new();
        }
    }
}
