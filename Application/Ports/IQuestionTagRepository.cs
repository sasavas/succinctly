using Domain.Features.TagFeature;

namespace Application.Ports;

public interface IQuestionTagRepository : IBaseRepository<TopicTag, TopicTagId>
{
    
}