using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace E_CommerceAPI.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public Collection<Basket> Baskets { get; set;}
    }
}
