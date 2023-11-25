using E_CommerceAPI.Application.Abstractions.Services;
using E_CommerceAPI.Application.ViewModels.Baskets;
using E_CommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Persistance.Services
{
    public class BasketService : IBasketService
    {
        public Task AddItemToBasketAsync(VM_Create_BasketItem create_BasketItem)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetAllBasketItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(VM_Update_BasketItem update_BasketItem)
        {
            throw new NotImplementedException();
        }
    }
}
