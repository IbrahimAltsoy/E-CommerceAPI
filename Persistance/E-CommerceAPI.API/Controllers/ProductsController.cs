using E_CommerceAPI.Application.Abstractions.Storage;
using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using E_CommerceAPI.Application.Features.Commands.Product.DeleteProduct;
using E_CommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using E_CommerceAPI.Application.Features.Queries.Product.GetAllProducts;
using E_CommerceAPI.Application.Features.Queries.Product.GetByIdAsyncProduct;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.Repositories.File;
using E_CommerceAPI.Application.Repositories.InvoiceFile;
using E_CommerceAPI.Application.Repositories.ProductImage;
using E_CommerceAPI.Application.RequestParameters;
using E_CommerceAPI.Application.Services;
using E_CommerceAPI.Application.ViewModels.Products;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        IWebHostEnvironment _webHostEnvironment;
       
       private readonly IFileReadRepository _fileReadRepository;
        readonly IFileWriteRepository _fileWriteRepository;
        readonly IProductImageReadRepository _productImageReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        readonly IStorageService _storageService;
        readonly IConfiguration _configuration;


        readonly IMediator _mediator;



        public ProductsController(IProductReadRepository productService, IProductWriteRepository productWriteRepository, IWebHostEnvironment webHostEnvironment, IFileReadRepository fileReadRepository = null, IFileWriteRepository fileWriteRepository = null, IProductImageReadRepository productImageReadRepository = null, IProductImageWriteRepository productImageWriteRepository = null, IInvoiceFileReadRepository invoiceFileReadRepository = null, IInvoiceFileWriteRepository invoiceFileWriteRepository = null, IStorageService storageService = null, IConfiguration configuration = null, IMediator mediator = null)
        {
            this._productReadRepository = productService;
            _productWriteRepository = productWriteRepository;
            _webHostEnvironment = webHostEnvironment;

            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _productImageReadRepository = productImageReadRepository;
            _productImageWriteRepository = productImageWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _storageService = storageService;
            _configuration = configuration;
            _mediator = mediator;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdAsyncQueryRequest getByIdAsyncQueryRequest)
        {
            GetByIdAsyncQueryResponse response = await _mediator.Send(getByIdAsyncQueryRequest);
        
           
            return Ok(response);
        }
        //[Guid("0B99B2A9-7DEB-48DC-BC15-01B5180FC0F5")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductsQueryRequest getAllProductsQueryRequest ) 
        { 
           GetAllProductsQueryResponse response= await _mediator.Send(getAllProductsQueryRequest); return Ok(response);
        //public IActionResult GetAll([FromQuery]Pagination pagination)
        //{

        //    var totalCount = _productReadRepository.GetAll(false).Count();
        //    var products = _productReadRepository.GetAll(true).Skip(pagination.Size * pagination.Page).Take(pagination.Size).Select(p => new
        //    {
        //        p.Id,
        //        p.Name,
        //        p.Description,
        //        p.Stock,
        //        p.Price


        //    }).ToList();
        //    return Ok(new
        //    {
        //        totalCount,
        //        products
        //    });
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var product = await _productReadService.GetByIdAsync(id, false);
        //    return Ok(product);
        //}
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response= await _mediator.Send(createProductCommandRequest);
        //    if (ModelState.IsValid)
        //    {
                
        //    }
        //    await _productWriteRepository.AddAsync(new()
        //    {

        //        Name = model.Name,
        //        Description = model.Description,
        //        Stock = model.Stock,
        //        Price = model.Price
        //    });
        //    await _productWriteRepository.SaveChanges();
            return StatusCode((int)HttpStatusCode.Created);


        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            await _mediator.Send(updateProductCommandRequest);
            //Product product = await _productReadRepository.GetByIdAsync(model.Id, true);
            //product.Name = model.Name;
            //product.Description = model.Description;
            //product.Stock = model.Stock;
            //product.Price = model.Price;
            
            //await _productWriteRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(/*string id*/ DeleteProductCommandRequest deleteProductCommandRequest)
        {
            await _mediator.Send(deleteProductCommandRequest);
            //var x = await _productWriteRepository.DeleteAsync(id);         
            //await _productWriteRepository.SaveChanges();            
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(string id)
        {
            //string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "resource/product-images");
            //if(!Directory.Exists(uploadPath))
            //    Directory.CreateDirectory(uploadPath);
            //Random r = new();
            //foreach (IFormFile file in Request.Form.Files)
            //{

            //    string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");
            //    using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024,useAsync:false); 
            //    await file.CopyToAsync(fileStream);
            //    await fileStream.FlushAsync();
            //}




            List<(string fileName,string pathOrContainerName)> result = await _storageService.UploadAsync("files", Request.Form.Files);
           Product product = await _productReadRepository.GetByIdAsync(id,true);
            await _productImageWriteRepository.AddRangeAsync(result.Select(p => new ProductImageFile()
            {
                FileName = p.fileName,
                Path = p.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() { product}
            }).ToList());
            await _productImageWriteRepository.SaveChanges();


            //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(p => new InvoiceFile()
            //{
            //    FileName = p.fileName,
            //    Path = p.path,
            //    Price = 100,
            //}).ToList());
            //await _invoiceFileWriteRepository.SaveChanges();
            //await _fileWriteRepository.AddRangeAsync(datas.Select(p => new Domain.Entities.File()
            //{
            //    FileName = p.fileName,
            //    Path = p.path,

            //}).ToList());
            //await _fileWriteRepository.SaveChanges();
            //var models =  _fileReadRepository.GetAll(false);
            //
            
            return Ok();
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages(string id)
        {
            Product? product = await _productReadRepository.Table.Include(p=>p.ProductImageFiles).FirstOrDefaultAsync(p=>p.Id==Guid.Parse(id));

            return Ok(product.ProductImageFiles.Select(p=> new
            {
               Path = $"{_configuration["StorageBaseUrl"]}/{p.Path}",    
                p.FileName,
                p.Id
            }));
        }
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id, string imageId)
        {
            Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));
            ProductImageFile productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(imageId));
            product.ProductImageFiles.Remove(productImageFile);
            await _productWriteRepository.SaveChanges();
            return Ok();


        }
      
    }
}
