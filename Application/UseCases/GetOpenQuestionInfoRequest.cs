using Application.Ports;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using MediatR;

namespace Application.UseCases;

public record OpenQuestionInfoDto(
    IEnumerable<CharLimitOption> CharLimitOptions,
    IEnumerable<TopicTag> QuestionTags
);

public record GetOpenQuestionInfoRequest : IRequest<OpenQuestionInfoDto>;

public class GetOpenQuestionInfoRequestHandler : IRequestHandler<GetOpenQuestionInfoRequest, OpenQuestionInfoDto>
{
    private readonly ITopicTagRepository _topicTagRepository;

    public GetOpenQuestionInfoRequestHandler(
        ITopicTagRepository topicTagRepository)
    {
        _topicTagRepository = topicTagRepository;
    }

    public Task<OpenQuestionInfoDto> Handle(GetOpenQuestionInfoRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(
            new OpenQuestionInfoDto(
                CharLimitOption.CharLimitOptions, 
                _topicTagRepository.GetList()));
    }
}