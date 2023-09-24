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
        UserId userId,
        string questionText,
        List<OptionAnswer> optionAnswers,
        List<QuestionTag> questionTags) : base(userId, questionText, questionTags)
    {
        if (optionAnswers.Count <= 1)
        {
            throw new QuestionnaireMustHaveAtLeastTwoOptionAnswersException(
                "Questionnaire must have at least two option answers");
        }

        _answers = optionAnswers;

        _poll = optionAnswers.ToDictionary(option => option, _ => 0);
    }

    private readonly List<OptionAnswer> _answers;
    private readonly Dictionary<OptionAnswer, int> _poll;


    public IEnumerable<OptionAnswer> GetOptionAnswers() => _answers.ToList();

    public ReadOnlyDictionary<OptionAnswer, int> Poll
        => _poll.ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value).AsReadOnly();

    public void Vote(string option)
    {
        var optionAnswer = new OptionAnswer(option);
        _poll[optionAnswer]++;
    }

    public KeyValuePair<OptionAnswer, int> GetMostVoted()
        => _poll.MaxBy(keyValue => keyValue.Value);

    public KeyValuePair<OptionAnswer, int> GetLeastVoted()
        => _poll.MinBy(keyValue => keyValue.Value);
}