namespace Domain.Features.QuestionFeature;

public class OpenAnswer
{
    public string AnswerText { get; set; }
    public OpenQuestion Question { get; private set; }

    private OpenAnswer(string answerText)
    {
        this.AnswerText = answerText;
    }

    public static OpenAnswer Create(string answerText)
    {
        return new OpenAnswer(answerText);
    }
}