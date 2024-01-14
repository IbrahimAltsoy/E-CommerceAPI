using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_CommerceAPI.Application.DTOs.Order
{
    public class ReadOrders_Dto
    {
        //public string OrderCode { get; set; }
        //public string UserName { get; set; }
        //public string Description { get; set; }
        //public string Address { get; set; }
        //public Date CreatedDate { get; set; }
        //public float TotalPrice { get; set; }
        public int TotalOrderCount { get; set; }
        public object Orders { get; set; }
    }
}
