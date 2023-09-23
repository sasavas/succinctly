namespace Domain.Features.UserFeature;

public class EmailAddress
{
    public EmailAddress(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
}