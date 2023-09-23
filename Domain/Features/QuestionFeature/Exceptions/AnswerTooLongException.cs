using Domain.Exceptions;

namespace Domain.Features.QuestionFeature.Exceptions;

public class AnswerTooLongException : SuccinctlyException
{
    public AnswerTooLongException(string? message) : base(message)
    {
    }
}