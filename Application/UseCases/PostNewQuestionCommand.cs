using Application.Ports;
using Application.Ports.OpenQuestionRepositories;
using Domain.Features.QuestionFeature;
using Domain.Features.QuestionFeature.Options;
using MediatR;

namespace Application.UseCases;

public record PostNewQuestionCommand(
    Guid UserId,
    string QuestionText,
    int CharLimitOptionId,
    List<int> TagIds
) : IRequest<OpenQuestion>;

public class PostNewQuestionHandler : IRequestHandler<PostNewQuestionCommand, OpenQuestion>
{
    private readonly IOpenQuestionRepository _openQuestionRepository;
    private readonly ITopicTagRepository _topicTagRepository;
    private readonly IUserRepository _userRepository;

    public PostNewQuestionHandler(
        IOpenQuestionRepository openQuestionRepository,
        ITopicTagRepository topicTagRepository,
        IUserRepository userRepository)
    {
        _openQuestionRepository = openQuestionRepository;
        _topicTagRepository = topicTagRepository;
        _userRepository = userRepository;
    }

    public Task<OpenQuestion> Handle(PostNewQuestionCommand request, CancellationToken cancellationToken)
    {
        var questionTags =
            _topicTagRepository.GetList(t => request.TagIds.Contains(t.Id));

        var user = _userRepository.Get(request.UserId);
        
        OpenQuestion question = new OpenQuestion(
            user,
            request.QuestionText,
            CharLimitOption.GetById(request.CharLimitOptionId),
            questionTags.ToList()
        );

        var addedQuestion = _openQuestionRepository.Add(question);

        return Task.FromResult(addedQuestion);
    }
}