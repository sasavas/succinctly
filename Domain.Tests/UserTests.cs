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

        Assert.Single(user.GetOpenQuestion());
    }

    [Fact]
    public void User_can_have_zero_to_N_Questionnaires()
    {
        var user = GetSampleUser();

        user.AskQuestionnaire(GetQuestionnaire());

        Assert.Single(user.GetQuestionnaires());
    }

    private static User GetSampleUser()
    {
        return new User(
            "Ahmet",
            "Can",
            new EmailAddress("ahmet@can.com"),
            new UserName("ahmetc"));
    }

    private static OpenQuestion GetOpenQuestion()
    {
        return new OpenQuestion(
            GetQuestionUser()
            ,"Some Question?"
            , new List<AnswerOption>()
            , new List<QuestionTag>());
    }

    private static Questionnaire GetQuestionnaire()
    {
        return new Questionnaire(
            GetQuestionUser()
            ,"Some questionnaire?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Revolt"),
                new OptionAnswer("Obey")
            }
            , new List<QuestionTag>());
    }

    private static User GetQuestionUser()
    {
        return new User(
            "Selim", "Oktay", new EmailAddress("test@test.com"), new UserName("selim"));
    }
}