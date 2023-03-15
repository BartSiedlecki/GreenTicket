namespace GreenTicket_WebAPI.Exceptions
{
    [Serializable]
    internal class BadRequestException : Exception
    {
        public BadRequestException(string? message) : base(message)
        {
        }
    }
}
