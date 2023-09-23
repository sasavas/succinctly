namespace Domain.Exceptions;

public class SuccinctlyException : Exception
{
    protected SuccinctlyException(string? message) : base(message)
    {
    }

    protected SuccinctlyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}