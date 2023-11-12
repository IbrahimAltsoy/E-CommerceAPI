namespace E_CommerceAPI.Application.Exceptions
{
    public class UserCreateFailledException : Exception
    {
        public UserCreateFailledException() : base("Kullanıcı oluştururken beklenilmeyen bir hata ile karşılaştı.") { }

        public UserCreateFailledException(string? message) : base(message)
        {
        }

        public UserCreateFailledException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
