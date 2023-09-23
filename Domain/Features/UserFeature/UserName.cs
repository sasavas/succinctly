namespace Domain.Features.UserFeature;

public class UserName
{
    public UserName(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
}