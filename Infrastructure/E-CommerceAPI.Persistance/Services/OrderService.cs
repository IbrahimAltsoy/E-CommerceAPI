using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.DTOs.Order;
using E_CommerceAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistance.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;

        public OrderService(IOrderWriteRepository orderWriteRepository)
        {
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task CreateOrderAsync(CreateOrder_Dto order)
        {
            await _orderWriteRepository.AddAsync(new()
            {
                Address = order.Address,
                Description = order.Description,
                Id = Guid.Parse(order.BasketId)
            });  
           await _orderWriteRepository.SaveChanges();
            

        }
    }
}
