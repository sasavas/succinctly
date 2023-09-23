using Domain.BaseTypes;

namespace Domain.Features.QuestionnaireFeature;

public class OptionAnswer : ValueObject
{
    public string Value { get; protected init; }

    public OptionAnswer(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}