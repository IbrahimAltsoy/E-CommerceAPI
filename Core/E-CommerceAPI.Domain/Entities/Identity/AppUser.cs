﻿using Microsoft.AspNetCore.Identity;

namespace E_CommerceAPI.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}