using E_CommerceAPI.Application.Abstraction;
using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Concreate;
using E_CommerceAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace E_CommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productService;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public ProductsController(IProductReadRepository productService, IProductWriteRepository productWriteRepository, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            this._productService = productService;
            _productWriteRepository = productWriteRepository;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }
        //[Guid("0B99B2A9-7DEB-48DC-BC15-01B5180FC0F5")]
        [HttpGet]
        public IActionResult Get()
        {
            var products = _userReadRepository.GetAll(true);
            return Ok(products);
        }
        [HttpPost]
        public async Task AddUser()
        {
            await _userWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), Name ="Ibrahim"}
            });
            await _productWriteRepository.SaveChanges();

        }
        //
        //[Guid("4ADCE470-26FA-4ABD-BEDD-E5F0B89BDD4F")]
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            User _user = await _userReadRepository.GetByIdAsync(user.Id.ToString(), true);
            _user.Name = user.Name;

            await _userWriteRepository.SaveChanges();
            return Ok();
        }
        //
    }
}
