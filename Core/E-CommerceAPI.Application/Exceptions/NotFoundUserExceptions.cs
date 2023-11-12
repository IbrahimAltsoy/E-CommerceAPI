using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Exceptions
{
    public class NotFoundUserExceptions : Exception
    {
        public NotFoundUserExceptions()
        {
        }

        public NotFoundUserExceptions(string? message) : base("Kullanıcı adı veya şifre hatalı")
        {
        }

        public NotFoundUserExceptions(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
