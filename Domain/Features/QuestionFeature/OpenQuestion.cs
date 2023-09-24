using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.QuestionFeature;

public class OpenQuestion : Question
{
    private OpenQuestion()
    {
        
    }
    
    public OpenQuestion(
        User user,
        string questionText,
        CharLimitOption charLimitOption,
        List<TopicTag> questionTags) : base(user, questionText, questionTags)
    {
        CharLimitOption = charLimitOption;
    }

    private IEnumerable<IAnswerOption> AnswerOptions
        => new List<IAnswerOption>()
        {
            CharLimitOption,
        };

    public Guid UserId { get; private set; }

    public readonly CharLimitOption CharLimitOption;

    public IEnumerable<OpenAnswer> Answers => _answers.ToList();
    private readonly ICollection<OpenAnswer> _answers = new List<OpenAnswer>();
    
    public void Answer(string answerText)
    {
        var answer = new OpenAnswer(this, answerText);

        foreach (var answerOption in AnswerOptions)
        {
            answerOption.Assert(answer);
        }

        _answers.Add(answer);
    }
}