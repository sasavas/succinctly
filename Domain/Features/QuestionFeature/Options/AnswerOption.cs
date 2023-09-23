namespace Domain.Features.QuestionFeature.Options;

public abstract class AnswerOption
{
    /// <summary>
    /// Throws exception if the option condition fails.
    /// </summary>
    public abstract void Assert(OpenAnswer answer);
}