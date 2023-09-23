namespace Domain.Features.UserFeature;

public class UserId
{
    public UserId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; set; }
}