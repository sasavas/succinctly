using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionFeature.Options;

public interface IAnswerOption
{
    /// <summary>
    /// Throws exception if the option condition fails.
    /// </summary>
    /// <exception cref="AnswerTooLongException"></exception>
    public abstract void Assert(OpenAnswer answer);
}