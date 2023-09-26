using Application.Ports;
using Domain.Features.TagFeature;

namespace Infrastructure.Database.Repositories;

public class TopicTagRepository : BaseRepository<TopicTag, int>, ITopicTagRepository
{
    public TopicTagRepository(SuccinctlyContext context) : base(context)
    {
    }
}