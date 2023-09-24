using Domain.BaseTypes;

namespace Domain.Features.QuestionFeature;

public class OpenAnswer : Entity<long>
{
    public string AnswerText { get; private set; }
    public OpenQuestion Question { get; private set; }

    public OpenAnswer( OpenQuestion question, string answerText)
    {
        this.AnswerText = answerText;
        Question = question;
    }
}