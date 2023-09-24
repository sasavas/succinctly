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
            GetQuestionOwnerId()
            ,"Some Question?"
            , new CharLimitOption(CharLimits.Short)
            , new List<QuestionTag>());
    }

    private static Questionnaire GetQuestionnaire()
    {
        return new Questionnaire(
            GetQuestionOwnerId()
            ,"Some questionnaire?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Revolt"),
                new OptionAnswer("Obey")
            }
            , new List<QuestionTag>());
    }

    private static UserId GetQuestionOwnerId() => new UserId(new Guid());
}