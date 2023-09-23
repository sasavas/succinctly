namespace Domain.Features.TagFeature;

public class QuestionTag
{
    public QuestionTag(string tagText)
    {
        TagText = tagText;
    }

    public string TagText { get; private set; }
}