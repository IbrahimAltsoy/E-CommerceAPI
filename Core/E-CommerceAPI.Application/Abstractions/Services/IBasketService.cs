using E_CommerceAPI.Application.ViewModels.Baskets;
using E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetAllBasketItemAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem create_BasketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem update_BasketItem);
        public Task RemoveBasketItemAsync(string id);

    }
}
