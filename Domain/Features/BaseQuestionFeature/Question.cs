using Domain.Features.TagFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question
{
    protected Question(string questionText, List<QuestionTag> tags)
    {
        QuestionText = questionText;
        Tags = tags;
    }

    private protected string QuestionText { get; set; }
    private protected List<QuestionTag> Tags { get; private set; }
    public IEnumerable<QuestionTag> GetTags() => Tags.ToList();
}