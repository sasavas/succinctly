using Domain.Features.QuestionFeature;

namespace Application.Ports.OpenQuestionRepositories;

public interface IOpenQuestionRepository : IBaseRepository<OpenQuestion, long>
{
    
}