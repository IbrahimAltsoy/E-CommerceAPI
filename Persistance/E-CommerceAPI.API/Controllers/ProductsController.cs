using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Persistance.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productService;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productService, IProductWriteRepository productWriteRepository)
        {
            this._productService = productService;
            _productWriteRepository = productWriteRepository;
        }
        //[Guid("0B99B2A9-7DEB-48DC-BC15-01B5180FC0F5")]
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll(true);
            return Ok(products);
        }
        [HttpPost]
        public async Task Add()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name="Product-11121", Description = "Product-12344", Stock=13, Price=73, CreatedDate=DateTime.UtcNow}
            });
            await _productWriteRepository.SaveChanges();
           
        }
    }
}
