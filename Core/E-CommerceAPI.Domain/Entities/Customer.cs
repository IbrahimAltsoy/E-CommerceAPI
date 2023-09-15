using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Domain.Entities
{
    public class Customer: BaseEntity
    {

        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
