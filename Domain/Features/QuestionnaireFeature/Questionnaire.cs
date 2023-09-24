using System.Collections.ObjectModel;
using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionnaireFeature.Exceptions;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.QuestionnaireFeature;

public class Questionnaire : Question
{
    private Questionnaire(){}
    
    public Questionnaire(
        User user,
        string questionText,
        List<QuestionnaireOption> optionAnswers,
        List<TopicTag> questionTags) : base(user, questionText, questionTags)
    {
        if (optionAnswers.Count <= 1)
        {
            throw new QuestionnaireMustHaveAtLeastTwoOptionAnswersException(
                "Questionnaire must have at least two option answers");
        }

        _answers = optionAnswers;

        _poll = optionAnswers.ToDictionary(option => option, _ => 0);
    }

    private readonly List<QuestionnaireOption> _answers;
    private readonly Dictionary<QuestionnaireOption, int> _poll;

    public Guid UserId { get; private set; }
    public IEnumerable<QuestionnaireOption> QuestionnaireOptions => _answers.ToList();

    public ReadOnlyDictionary<QuestionnaireOption, int> Poll
        => _poll.ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value).AsReadOnly();

    public void Vote(string option)
    {
        var optionAnswer = new QuestionnaireOption(option);
        _poll[optionAnswer]++;
    }

    public KeyValuePair<QuestionnaireOption, int> GetMostVoted()
        => _poll.MaxBy(keyValue => keyValue.Value);

    public KeyValuePair<QuestionnaireOption, int> GetLeastVoted()
        => _poll.MinBy(keyValue => keyValue.Value);
}