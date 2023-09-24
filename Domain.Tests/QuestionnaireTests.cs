using Domain.Features.QuestionnaireFeature;
using Domain.Features.QuestionnaireFeature.Exceptions;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Tests;

public class QuestionnaireTests
{
    [Fact]
    public void Questionnaire_has_TextOptionAnswers()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetQuestionnaireOwner()
            , "What should I do if my family want me out of the house?"
            , new List<QuestionnaireOption>
            {
                new TextQuestionnaireOption("Revolt"),
                new TextQuestionnaireOption("Obey")
            }
            , new List<TopicTag>());

        Assert.Equal(2, questionnaire.QuestionnaireOptions.Count());
        Assert.Equal("Revolt", questionnaire.QuestionnaireOptions.First().Value);
    }

    [Fact]
    public void Questionnaire_must_have_at_least_two_optionAnswers()
    {
        var action = () =>
        {
            Questionnaire questionnaire = new Questionnaire(
                GetQuestionnaireOwner()
                , "What should I do if my family want me out of the house?"
                , new List<QuestionnaireOption> { new QuestionnaireOption("Revolt") }
                , new List<TopicTag>());
        };

        Assert.Throws<QuestionnaireMustHaveAtLeastTwoOptionAnswersException>(action);
    }

    [Fact]
    public void Questionnaire_has_poll()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetQuestionnaireOwner()
            , "Who do you like more?"
            , new List<QuestionnaireOption>
            {
                new QuestionnaireOption("Mother"),
                new QuestionnaireOption("Father"),
                new QuestionnaireOption("Sister")
            }
            , new List<TopicTag>());

        questionnaire.Vote("Mother");
        questionnaire.Vote("Mother");
        questionnaire.Vote("Father");
        questionnaire.Vote("Father");
        questionnaire.Vote("Mother");
        questionnaire.Vote("Sister");

        var mostVoted = questionnaire.GetMostVoted();
        Assert.Equal(new QuestionnaireOption("Mother"), mostVoted.Key);
        Assert.Equal(3, mostVoted.Value);

        var leastVoted = questionnaire.GetLeastVoted();
        Assert.Equal(new QuestionnaireOption("Sister"), leastVoted.Key);
        Assert.Equal(1, leastVoted.Value);
        
        Assert.Equal(3, questionnaire.Poll.Count);
    }

    [Fact]
    public void Questionnaire_has_tags()
    {
        Questionnaire questionnaire = new Questionnaire(
            GetQuestionnaireOwner()
            , "Who do you like more?"
            , new List<QuestionnaireOption>
            {
                new QuestionnaireOption("Mother"),
                new QuestionnaireOption("Father"),
                new QuestionnaireOption("Sister")
            }
            , new List<TopicTag> { new TopicTag("Test") });

        Assert.Single(questionnaire.Tags);
    }

    [Fact]
    public void Questionnaire_must_have_multiple_ImageOptionAnswer()
    {
        var action = () =>
        {
            var questionnaire = new Questionnaire(
                GetQuestionnaireOwner(),
                "Which dress should I buy?"
                , new List<QuestionnaireOption>
                {
                    new ImageQuestionnaireOption("path/to/image")
                }
                , new List<TopicTag>());
        };

        Assert.Throws<QuestionnaireMustHaveAtLeastTwoOptionAnswersException>(action);
    }

    private static User GetQuestionnaireOwner() => 
        new User("Ali", "Can", new EmailAddress("test@test.com"), new UserName("user2"));
}