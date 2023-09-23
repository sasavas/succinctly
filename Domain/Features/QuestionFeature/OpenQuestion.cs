using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;

namespace Domain.Features.QuestionFeature;

public class OpenQuestion
{
    public string QuestionText { get; private set; }
    private List<AnswerOption> AnswerOptions { get; set; }
    private List<OpenAnswer> Answers { get; set; } = new();
    private List<QuestionTag> Tags { get; set; }

    public OpenQuestion(
        string questionText, 
        List<AnswerOption> answerOptions, 
        List<QuestionTag> questionTags)
    {
        QuestionText = questionText;
        AnswerOptions = answerOptions;
        Tags = questionTags;
    }

    public IEnumerable<OpenAnswer> GetAnswers() => Answers.ToList();
    
    public IEnumerable<QuestionTag> GetTags() => Tags.ToList();

    public void Answer(string answerText)
    {
        var answer = OpenAnswer.Create(answerText);
        
        AnswerOptions.ForEach(option => option.Assert(answer));
        
        Answers.Add(answer);
    }
}