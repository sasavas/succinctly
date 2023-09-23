using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;

namespace Domain.Features.QuestionFeature;

public class OpenQuestion : Question
{
    private List<AnswerOption> AnswerOptions { get; set; }
    private List<OpenAnswer> Answers { get; set; } = new();

    public OpenQuestion(
        string questionText, 
        List<AnswerOption> answerOptions, 
        List<QuestionTag> questionTags) : base(questionText, questionTags)
    {
        AnswerOptions = answerOptions;
    }

    public IEnumerable<OpenAnswer> GetAnswers() => Answers.ToList();

    public void Answer(string answerText)
    {
        var answer = OpenAnswer.Create(answerText);
        
        AnswerOptions.ForEach(option => option.Assert(answer));
        
        Answers.Add(answer);
    }
}