using System.Collections.ObjectModel;
using Domain.Features.BaseQuestionFeature;
using Domain.Features.QuestionnaireFeature.Exceptions;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Features.QuestionnaireFeature;

public class Questionnaire : Question
{
    private List<OptionAnswer> Answers { get; set; }
    private Dictionary<OptionAnswer, int> Poll { get; init; }

    public Questionnaire(
        User user,
        string questionText,
        List<OptionAnswer> optionAnswers,
        List<QuestionTag> questionTags) : base(user, questionText, questionTags)
    {
        if (optionAnswers.Count <= 1)
        {
            throw new QuestionnaireMustHaveAtLeastTwoOptionAnswersException(
                "Questionnaire must have at least two option answers");
        }

        Answers = optionAnswers;

        Poll = optionAnswers.ToDictionary(option => option, _ => 0);
    }

    public IEnumerable<OptionAnswer> GetOptionAnswers() => Answers.ToList();

    public ReadOnlyDictionary<OptionAnswer, int> GetPoll()
        => Poll.ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value).AsReadOnly();

    public void Vote(string option)
    {
        var optionAnswer = new OptionAnswer(option);
        Poll[optionAnswer]++;
    }

    public KeyValuePair<OptionAnswer, int> GetMostVoted()
        => Poll.MaxBy(keyValue => keyValue.Value);

    public KeyValuePair<OptionAnswer, int> GetLeastVoted()
        => Poll.MinBy(keyValue => keyValue.Value);
}