using Domain.Features.QuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.QuestionnaireFeature;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Tests;

public class UserTests
{
    [Fact]
    public void User_can_have_zero_to_N_OpenQuestions()
    {
        var user = GetSampleUser();

        user.AskOpenQuestion(GetOpenQuestion());

        Assert.Single(user.OpenQuestions);
    }

    [Fact]
    public void User_can_have_zero_to_N_Questionnaires()
    {
        var user = GetSampleUser();

        user.AskQuestionnaire(GetQuestionnaire());

        Assert.Single(user.Questionnaires);
    }

    private static User GetSampleUser()
    {
        return new User(
            "Ahmet",
            "Can",
            new EmailAddress("ahmet@can.com"),
            new UserName("ahmet"));
    }

    private static OpenQuestion GetOpenQuestion()
    {
        return new OpenQuestion(
            GetQuestionOwner()
            ,"Some Question?"
            , new CharLimitOption(CharLimits.Short)
            , new List<TopicTag>());
    }

    private static Questionnaire GetQuestionnaire()
    {
        return new Questionnaire(
            GetQuestionOwner()
            ,"Some questionnaire?"
            , new List<QuestionnaireOption>
            {
                new QuestionnaireOption("Revolt"),
                new QuestionnaireOption("Obey")
            }
            , new List<TopicTag>());
    }

    private static User GetQuestionOwner()
        => new User("Ali", "Can", new EmailAddress("test@test.com"), new UserName("user2"));
}