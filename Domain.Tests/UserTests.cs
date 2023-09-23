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

    [Fact]
    public void User_can_answer_questions()
    {
        var user = GetSampleUser();
        
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
            "Some Question"
            , new List<AnswerOption>()
            , new List<QuestionTag>());
    }

    private static Questionnaire GetQuestionnaire()
    {
        return new Questionnaire(
            "What should I do if my family want me out of the house?"
            , new List<OptionAnswer>
            {
                new OptionAnswer("Revolt"),
                new OptionAnswer("Obey")
            }
            , new List<QuestionTag>());
    }
}