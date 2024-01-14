﻿using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
       // public Guid BasketId { get; set; }
        //public Guid CustomerId { get; set; }
   

       // public ICollection<Product> Products { get; set; }
        //public Customer Customer { get; set; }
        public Basket Basket { get; set; }
        public CompletedOrder CompletedOrder { get; set; }
    }
}
