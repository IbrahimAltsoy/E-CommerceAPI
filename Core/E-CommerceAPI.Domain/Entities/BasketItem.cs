using E_CommerceAPI.Domain.Entities.Common;
using System.Collections.ObjectModel;

namespace E_CommerceAPI.Domain.Entities
{
    public class BasketItem:BaseEntity
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public Basket Basket { get; set; }
        public Product Product { get; set; }
    }
}
