using Domain.BaseTypes;

namespace Domain.Features.TagFeature;

public class QuestionTag : Entity<int>
{
    public QuestionTag(string tagText)
    {
        TagText = tagText;
    }

    public string TagText { get; private set; }
}