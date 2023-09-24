using Domain.BaseTypes;

namespace Domain.Features.QuestionnaireFeature;

public class QuestionnaireOption : ValueObject
{
    public string Value { get; protected init; }
    public Questionnaire Questionnaire { get; private set; }

    public QuestionnaireOption(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}