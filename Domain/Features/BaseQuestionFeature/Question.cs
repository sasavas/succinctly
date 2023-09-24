using Domain.BaseTypes;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question : Entity<long>
{
    protected Question()
    {
        
    }
    
    protected Question(UserId userId, string questionText, List<QuestionTag> tags)
    {
        UserId = userId;
        QuestionText = questionText;
        _tags = tags;
    }

    public UserId UserId { get; private set; }

    public string QuestionText { get; private set; }

    public IEnumerable<QuestionTag> TagIds => _tags.ToList();
    private protected readonly List<QuestionTag> _tags;

    public IEnumerable<User> UserLikes => _userLikes.ToList();
    private readonly List<User> _userLikes = new();

    public void UserLike(User user)
    {
        _userLikes.Add(user);
    }
}