using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.QuestionFeature;

public class OpenQuestion : Question
{
    private List<IAnswerOption> AnswerOptions { get; set; }
    private List<OpenAnswer> Answers { get; set; } = new();

    public OpenQuestion(
        UserId userId,
        string questionText,
        List<IAnswerOption> answerOptions,
        List<QuestionTagId> questionTags) : base(userId, questionText, questionTags)
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