using Domain.BaseTypes;
using Domain.Features.QuestionFeature;
using Domain.Features.QuestionnaireFeature;

namespace Domain.Features.TagFeature;

public class TopicTag : Entity<int>
{
    public TopicTag(string tagText)
    {
        TagText = tagText;
    }

    public string TagText { get; private set; }

    public ICollection<OpenQuestion> OpenQuestions { get; set; }
    public ICollection<Questionnaire> Questionnaires { get; set; }
    
}