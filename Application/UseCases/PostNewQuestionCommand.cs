using Application.Ports;
using Domain.Features.QuestionFeature;
using Domain.Features.QuestionFeature.Options;
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

    public PostNewQuestionHandler(
        IOpenQuestionRepository openQuestionRepository,
        ICharLimitOptionRepository charLimitOptionRepository)
    {
        _openQuestionRepository = openQuestionRepository;
        _charLimitOptionRepository = charLimitOptionRepository;
    }

    public Task<OpenQuestion> Handle(PostNewQuestionCommand request, CancellationToken cancellationToken)
    {
        var charLimitOption = _charLimitOptionRepository.Get(request.CharLimitOptionId);
        var answerOptions = new List<IAnswerOption>
        {
            charLimitOption
        };

        var questionTagIds = request.TagIds.Select(tag => new QuestionTagId(tag)).ToList();

        OpenQuestion question = new OpenQuestion(
            new UserId(request.UserId),
            request.QuestionText,
            answerOptions,
            questionTagIds
        );

        var addedQuestion = _openQuestionRepository.Add(question);

        return Task.FromResult(addedQuestion);
    }
}