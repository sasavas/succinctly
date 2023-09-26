using Domain.Features.QuestionFeature;
using MediatR;

namespace Application.UseCases;

public record GetOpenQuestionRequest(long Id) : IRequest<OpenQuestion>;

public class GetOpenQuestionRequestHandler : IRequestHandler<GetOpenQuestionRequest, OpenQuestion>
{
    public Task<OpenQuestion> Handle(GetOpenQuestionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}