using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question
{
    protected Question(UserId userId, string questionText, List<QuestionTagId> tags)
    {
        QuestionText = questionText;
        TagIds = tags;
        UserId = userId;
    }

    private protected UserId UserId { get; set; }

    private protected string QuestionText { get; set; }

    private protected List<QuestionTagId> TagIds { get; private set; }
    public IEnumerable<QuestionTagId> GetTags() => TagIds.ToList();

    public IEnumerable<User> GetUserLikes() => UserLikes.ToList();
    private List<User> UserLikes { get; set; } = new();

    public void UserLike(User user)
    {
        UserLikes.Add(user);
    }
}