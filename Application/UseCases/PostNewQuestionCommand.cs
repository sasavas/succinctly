using Application.Ports;
using Application.Ports.OpenQuestionRepositories;
using Domain.Features.QuestionFeature;
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
    private readonly ICharLimitOptionRepository _charLimitOptionRepository;
    private readonly IQuestionTagRepository _questionTagRepository;
    private readonly IUserRepository _userRepository;

    public PostNewQuestionHandler(
        IOpenQuestionRepository openQuestionRepository,
        ICharLimitOptionRepository charLimitOptionRepository,
        IQuestionTagRepository questionTagRepository,
        IUserRepository userRepository)
    {
        _openQuestionRepository = openQuestionRepository;
        _charLimitOptionRepository = charLimitOptionRepository;
        _questionTagRepository = questionTagRepository;
        _userRepository = userRepository;
    }

    public Task<OpenQuestion> Handle(PostNewQuestionCommand request, CancellationToken cancellationToken)
    {
        var charLimitOption = _charLimitOptionRepository.Get(request.CharLimitOptionId);

        var questionTags =
            _questionTagRepository.GetList(t => request.TagIds.Contains(t.Id));

        var user = _userRepository.Get(request.UserId);
        
        OpenQuestion question = new OpenQuestion(
            user,
            request.QuestionText,
            charLimitOption,
            questionTags.ToList()
        );

        var addedQuestion = _openQuestionRepository.Add(question);

        return Task.FromResult(addedQuestion);
    }
}