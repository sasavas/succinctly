namespace Domain.Features.QuestionFeature;

public class OpenAnswer
{
    public string AnswerText { get; set; }

    private OpenAnswer(string answerText)
    {
        this.AnswerText = answerText;
    }

    public static OpenAnswer Create(string answerText)
    {
        return new OpenAnswer(answerText);
    }
}