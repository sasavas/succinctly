using Application.Ports;
using Application.Ports.OpenQuestionRepositories;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using MediatR;

namespace Application.UseCases;

public record OpenQuestionInfoDto(
    IEnumerable<CharLimitOption> CharLimitOptions,
    IEnumerable<QuestionTag> QuestionTags
);

public record GetOpenQuestionInfoRequest : IRequest<OpenQuestionInfoDto>;

public class GetOpenQuestionInfoRequestHandler : IRequestHandler<GetOpenQuestionInfoRequest, OpenQuestionInfoDto>
{
    private readonly ICharLimitOptionRepository _charLimitOptionRepository;
    private readonly IQuestionTagRepository _questionTagRepository;

    public GetOpenQuestionInfoRequestHandler(
        IOpenQuestionRepository openQuestionRepository,
        ICharLimitOptionRepository charLimitOptionRepository,
        IQuestionTagRepository questionTagRepository)
    {
        _charLimitOptionRepository = charLimitOptionRepository;
        _questionTagRepository = questionTagRepository;
    }

    public Task<OpenQuestionInfoDto> Handle(GetOpenQuestionInfoRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(
            new OpenQuestionInfoDto(
                _charLimitOptionRepository.GetList(), 
                _questionTagRepository.GetList()));
    }
}