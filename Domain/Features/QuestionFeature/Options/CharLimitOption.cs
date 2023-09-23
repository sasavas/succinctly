using Domain.BaseTypes;
using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionFeature.Options;

public class CharLimitOption : Entity<int>, IAnswerOption
{
    private int CharLimit { get; set; }
    
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

    public void Assert(OpenAnswer answer)
    {
        if (answer.AnswerText.Trim().Length > CharLimit)
        {
            throw new AnswerTooLongException("Answer is too long");
        }
    }
}