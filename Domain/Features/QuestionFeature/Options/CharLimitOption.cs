using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionFeature.Options;

public class CharLimitOption : AnswerOption
{
    public int CharLimit { get; private set; }
    
    public CharLimitOption(CharLimits limit)
    {
        CharLimit = limit switch
        {
            CharLimits.Short => 127,
            CharLimits.Long => 512,
            CharLimits.Relax => 1024,
            _ => throw new ArgumentOutOfRangeException(nameof(limit), limit, null)
        };
    }

    public override void Assert(OpenAnswer answer)
    {
        if (answer.AnswerText.Trim().Length > CharLimit)
        {
            throw new AnswerTooLongException("Answer is too long");
        }
    }
}