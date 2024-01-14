using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Domain.Entities
{
    public class CompletedOrder:BaseEntity
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
