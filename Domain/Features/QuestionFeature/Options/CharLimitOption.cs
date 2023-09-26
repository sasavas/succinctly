using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionFeature.Options;

public class CharLimitOption : IAnswerOption
{
    public int Id { get; private set; }
    public int CharLimit { get; private set; }

    private CharLimitOption()
    {
    }

    public CharLimitOption(CharLimitOptions limitOption)
    {
        CharLimit = limitOption switch
        {
            Options.CharLimitOptions.Short => 127,
            Options.CharLimitOptions.Long => 512,
            Options.CharLimitOptions.Relax => 1024,
            _ => throw new ArgumentOutOfRangeException(nameof(limitOption), limitOption, null)
        };

        Id = (int)limitOption;
    }

    public static IEnumerable<CharLimitOption> CharLimitOptions
        => Enum.GetValues<CharLimitOptions>().Select(charLimits => new CharLimitOption(charLimits));

    public static CharLimitOption GetById(int id) => new CharLimitOption((CharLimitOptions)id);

    public void Assert(OpenAnswer answer)
    {
        if (answer.AnswerText.Trim().Length > CharLimit)
        {
            throw new AnswerTooLongException("Answer is too long");
        }
    }
}