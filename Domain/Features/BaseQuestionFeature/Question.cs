using Domain.BaseTypes;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question : Entity<long>
{
    protected Question(UserId userId, string questionText, List<QuestionTagId> tagIds)
    {
        UserId = userId;
        QuestionText = questionText;
        _tagIdIds = tagIds;
    }

    public UserId UserId { get; private set; }

    public string QuestionText { get; private set; }

    public IEnumerable<QuestionTagId> TagIds => _tagIdIds.ToList();
    private protected readonly List<QuestionTagId> _tagIdIds;

    public IEnumerable<User> UserLikes => _userLikes.ToList();
    private readonly List<User> _userLikes = new();

    public void UserLike(User user)
    {
        _userLikes.Add(user);
    }
}