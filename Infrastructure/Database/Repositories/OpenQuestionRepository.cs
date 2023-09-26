using Application.Ports.OpenQuestionRepositories;
using Domain.Features.QuestionFeature;

namespace Infrastructure.Database.Repositories;

public class OpenQuestionRepository : BaseRepository<OpenQuestion, long>, IOpenQuestionRepository
{
    public OpenQuestionRepository(SuccinctlyContext context) : base(context)
    {
    }
}