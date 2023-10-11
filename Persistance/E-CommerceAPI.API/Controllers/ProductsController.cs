using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.RequestParameters;
using E_CommerceAPI.Application.ViewModels.Products;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadService;
        private readonly IProductWriteRepository _productWriteRepository;
        IWebHostEnvironment _webHostEnvironment;


        public ProductsController(IProductReadRepository productService, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._productReadService = productService;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;

        }
        //[Guid("0B99B2A9-7DEB-48DC-BC15-01B5180FC0F5")]
        [HttpGet]
        public IActionResult GetAll([FromQuery]Pagination pagination)
        {
            var totalCount = _productReadService.GetAll(false).Count();
            var products = _productReadService.GetAll(true).Skip(pagination.Size * pagination.Page).Take(pagination.Size).Select(p => new
            {
               p.Id,
                p.Name,
                p.Description,
                p.Stock,
                p.Price               


            }).ToList();
            return Ok(new
            {
                totalCount,
                products
            });
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var product = await _productReadService.GetByIdAsync(id, false);
        //    return Ok(product);
        //}
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
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");
            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            Random r = new();
            foreach (IFormFile file in Request.Form.Files)
            {
                
                string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");
                using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024,useAsync:false); 
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }
            return Ok();
        }
      
    }
}
