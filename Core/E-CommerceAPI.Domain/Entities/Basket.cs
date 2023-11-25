using E_CommerceAPI.Domain.Entities.Common;
using E_CommerceAPI.Domain.Entities.Identity;
using System.Collections.ObjectModel;

namespace E_CommerceAPI.Domain.Entities
{
    public class Basket:BaseEntity
    {
        public string UserId { get; set; }
       
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public Collection<BasketItem> BasketItems { get; set; }
    }
}
