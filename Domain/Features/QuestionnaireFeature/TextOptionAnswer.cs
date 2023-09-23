using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionnaireFeature;

public class TextOptionAnswer : OptionAnswer
{
    public TextOptionAnswer(string answerText) : base(answerText)
    {
        if (answerText.Length > 127)
        {
            throw new AnswerTooLongException("Optional Answers cannot be longer than 127 characters");
        }

        Value = answerText;
    }
}