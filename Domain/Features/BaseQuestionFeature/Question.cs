using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question
{
    protected Question(User user, string questionText, List<QuestionTag> tags)
    {
        QuestionText = questionText;
        Tags = tags;
        User = user;
    }

    private protected User User { get; set; }

    private protected string QuestionText { get; set; }

    private protected List<QuestionTag> Tags { get; private set; }
    public IEnumerable<QuestionTag> GetTags() => Tags.ToList();

    public IEnumerable<User> GetUserLikes() => UserLikes.ToList();
    private List<User> UserLikes { get; set; } = new();

    public void UserLike(User user)
    {
        UserLikes.Add(user);
    }
}