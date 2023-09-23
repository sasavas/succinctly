using Domain.Exceptions;

namespace Domain.Features.QuestionnaireFeature.Exceptions;

public class QuestionnaireMustHaveAtLeastTwoOptionAnswersException :  SuccinctlyException
{
    public QuestionnaireMustHaveAtLeastTwoOptionAnswersException(string? message) : base(message)
    {
    }
}