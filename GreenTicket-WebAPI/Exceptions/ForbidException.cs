namespace GreenTicket_WebAPI.Exceptions
{
    public class ForbidException : Exception
    {
        public ForbidException()
        {
        }

        public ForbidException(string? message) : base(message)
        {
        }
    }
}
