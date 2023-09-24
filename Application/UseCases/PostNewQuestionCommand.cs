using Application.Ports;
using Application.Ports.OpenQuestionRepositories;
using Domain.Features.QuestionFeature;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;
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

    public PostNewQuestionHandler(
        IOpenQuestionRepository openQuestionRepository,
        ICharLimitOptionRepository charLimitOptionRepository,
        IQuestionTagRepository questionTagRepository)
    {
        _openQuestionRepository = openQuestionRepository;
        _charLimitOptionRepository = charLimitOptionRepository;
        _questionTagRepository = questionTagRepository;
    }

    public Task<OpenQuestion> Handle(PostNewQuestionCommand request, CancellationToken cancellationToken)
    {
        var charLimitOption = _charLimitOptionRepository.Get(request.CharLimitOptionId);

        var questionTags = 
            _questionTagRepository.GetList(t => request.TagIds.Contains(t.Id));

        OpenQuestion question = new OpenQuestion(
            new UserId(request.UserId),
            request.QuestionText,
            charLimitOption,
            questionTags.ToList()
        );

        var addedQuestion = _openQuestionRepository.Add(question);

        return Task.FromResult(addedQuestion);
    }
}