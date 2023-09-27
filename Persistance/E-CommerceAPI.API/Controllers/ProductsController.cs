using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.ViewModels.Products;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Concreate;
using E_CommerceAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadService;
        private readonly IProductWriteRepository _productWriteRepository;


        public ProductsController(IProductReadRepository productService, IProductWriteRepository productWriteRepository)
        {
            this._productReadService = productService;
            _productWriteRepository = productWriteRepository;

        }
        //[Guid("0B99B2A9-7DEB-48DC-BC15-01B5180FC0F5")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productReadService.GetAll(false);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product =await _productReadService.GetByIdAsync(id,false);
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(VM_Product_Create model)
        {
            if (ModelState.IsValid)
            {
                
            }
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Description = model.Description,
                Stock = model.Stock,
                Price = model.Price
            });
            await _productWriteRepository.SaveChanges();
            return StatusCode((int)HttpStatusCode.Created);


        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(VM_Product_Update model)
        {
            Product product = await _productReadService.GetByIdAsync(model.Id, true);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Stock = model.Stock;
            product.Price = model.Price;
            
            await _productWriteRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var x = await _productWriteRepository.DeleteAsync(id);         
            await _productWriteRepository.SaveChanges();            
            return Ok();
        }
      
    }
}
