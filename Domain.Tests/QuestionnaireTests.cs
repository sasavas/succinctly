using Domain.Features.QuestionnaireFeature;
using Domain.Features.QuestionnaireFeature.Exceptions;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Tests;

public class QuestionnaireTests
{
    [Fact]
    public void Questionnaire_has_OptionAnswers()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetSampleUser()
            , "What should I do if my family want me out of the house?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Revolt"),
                new OptionAnswer("Obey")
            }
            , new List<QuestionTag>());

        Assert.Equal(2, questionnaire.GetOptionAnswers().Count());
        Assert.Equal("Revolt", questionnaire.GetOptionAnswers().First().Value);
    }

    [Fact]
    public void Questionnaire_must_have_at_least_two_optionAnswers()
    {
        var action = () =>
        {
            Questionnaire questionnaire = new Questionnaire(
                GetSampleUser()
                , "What should I do if my family want me out of the house?"
                , new List<OptionAnswer> { new OptionAnswer("Revolt") }
                , new List<QuestionTag>());
        };

        Assert.Throws<QuestionnaireMustHaveAtLeastTwoOptionAnswersException>(action);
    }

    [Fact]
    public void Questionnaire_has_poll()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetSampleUser()
            , "Who do you like more?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Mother"),
                new OptionAnswer("Father"),
                new OptionAnswer("Sister")
            }
            , new List<QuestionTag>());

        questionnaire.Vote("Mother");
        questionnaire.Vote("Mother");
        questionnaire.Vote("Father");
        questionnaire.Vote("Father");
        questionnaire.Vote("Mother");
        questionnaire.Vote("Sister");

        var mostVoted = questionnaire.GetMostVoted();
        Assert.Equal(new OptionAnswer("Mother"), mostVoted.Key);
        Assert.Equal(3, mostVoted.Value);

        var leastVoted = questionnaire.GetLeastVoted();
        Assert.Equal(new OptionAnswer("Sister"), leastVoted.Key);
        Assert.Equal(1, leastVoted.Value);
    }

    [Fact]
    public void Questionnaire_has_tags()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetSampleUser()
            , "Who do you like more?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Mother"),
                new OptionAnswer("Father"),
                new OptionAnswer("Sister")
            }
            , new List<QuestionTag> { new QuestionTag("Private Life") });

        Assert.Single(questionnaire.GetTags());
    }

    [Fact]
    public void Questionnaire_must_have_multiple_ImageOptionAnswer()
    {
        var action = () =>
        {
            var questionnaire = new Questionnaire(
                GetSampleUser(),
                "Which dress should I buy?"
                , new List<OptionAnswer>
                {
                    new ImageOptionAnswer("path/to/image")
                }
                , new List<QuestionTag> { new QuestionTag("Personal Question") });
        };

        Assert.Throws<QuestionnaireMustHaveAtLeastTwoOptionAnswersException>(action);
    }

    private static User GetSampleUser()
        => new User("Ahmet", "Can", new EmailAddress("ahmet@can.com"), new UserName("ahmetc"));
}