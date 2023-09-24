using Domain.Features.QuestionFeature.Exceptions;

namespace Domain.Features.QuestionnaireFeature;

public class TextQuestionnaireOption : QuestionnaireOption
{
    public TextQuestionnaireOption(string answerText) : base(answerText)
    {
        if (answerText.Length > 127)
        {
            throw new AnswerTooLongException("Optional Answers cannot be longer than 127 characters");
        }

        Value = answerText;
    }
}