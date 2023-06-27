namespace AgendasTech.Domain.Core.Exceptions
{
    public class ErrorValidationException : Exception
    {
        public ErrorValidationException(string? message) : base(message)
        {
        }
    }
}
