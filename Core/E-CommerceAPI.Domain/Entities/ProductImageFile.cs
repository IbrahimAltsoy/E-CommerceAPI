namespace E_CommerceAPI.Domain.Entities
{
    public class ProductImageFile:File
    {
        public ICollection<Product> Products { get; set; }
    }
}
