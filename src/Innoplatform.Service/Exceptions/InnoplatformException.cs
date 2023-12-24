namespace Innoplatform.Service.Exceptions
{
    public class InnoplatformException : Exception
    {
        public int statusCode;
        public InnoplatformException(int code, string message) : base(message)
        {
            this.statusCode = code;
        }
    }
}
