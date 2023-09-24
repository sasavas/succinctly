using Domain.BaseTypes;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.BaseQuestionFeature;

public abstract class Question : Entity<long>
{
    protected Question()
    {
        
    }
    
    protected Question(User user, string questionText, List<TopicTag> tags)
    {
        User = user;
        QuestionText = questionText;
        _tags = tags;
    }

    public User User { get; private set; }

    public string QuestionText { get; private set; }

    public IEnumerable<TopicTag> Tags => _tags.ToList();
    private protected readonly List<TopicTag> _tags;

    public IEnumerable<User> Users => _userLikes.ToList();
    private readonly List<User> _userLikes = new();

    public void UserLike(User user)
    {
        _userLikes.Add(user);
    }
}