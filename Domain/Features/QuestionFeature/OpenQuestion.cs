using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.QuestionFeature;

public class OpenQuestion : Question
{
    public OpenQuestion(
        UserId userId,
        string questionText,
        CharLimitOption charLimitOption,
        List<QuestionTagId> questionTagIds) : base(userId, questionText, questionTagIds)
    {
        _charLimitOption = charLimitOption;
    }

    private IEnumerable<IAnswerOption> AnswerOptions
        => new List<IAnswerOption>()
        {
            _charLimitOption,
        };

    private readonly CharLimitOption _charLimitOption;

    public IEnumerable<OpenAnswer> Answers => _answers.ToList();
    private readonly ICollection<OpenAnswer> _answers = new List<OpenAnswer>();


    public void Answer(string answerText)
    {
        var answer = OpenAnswer.Create(answerText);

        foreach (var answerOption in AnswerOptions)
        {
            answerOption.Assert(answer);
        }

        _answers.Add(answer);
    }
}