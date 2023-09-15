using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
       
    }
}
