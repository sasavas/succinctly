using Domain.Features.QuestionFeature;
using Domain.Features.QuestionFeature.Exceptions;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using Domain.Features.UserFeature;

namespace Domain.Tests;

public class OpenQuestionTests
{
    [Fact]
    public void Open_Ended_Question_has_multiple_answers()
    {
        OpenQuestion question = new OpenQuestion(
            GetOpenQuestionOwner(),
            GetQuestionText()
            , new CharLimitOption(CharLimitOptions.Short)
            , new List<TopicTag>());

        question.Answer("You can cook the tomato first and then add the lettuce," +
                        " finally a pinch of salt.");

        Assert.Single(question.Answers);
    }

    [Fact]
    public void Open_Ended_Question_answer_texts_exceeding_the_set_limit_chars_throws_error()
    {
        OpenQuestion question = new OpenQuestion(
            GetOpenQuestionOwner(),
            GetQuestionText()
            ,  new CharLimitOption(CharLimitOptions.Short)
            , new List<TopicTag>());

        var action = () => question.Answer("This is quite a long answer text for a reasonably simple question." +
                                           " You may consider setting a looser limit so that the user can actually answer.");

        Assert.Throws<AnswerTooLongException>(action);
    }

    [Fact]
    public void Question_Has_Tags()
    {
        OpenQuestion question = new OpenQuestion(
            GetOpenQuestionOwner(),
            GetQuestionText(),
            new CharLimitOption(CharLimitOptions.Short),
            new List<TopicTag>() { new TopicTag("test")});

        Assert.Single(question.Tags);
    }

    private static User GetOpenQuestionOwner()
        => new User("Ali", "Can", new EmailAddress("test@test.com"), new UserName("user1"));


    private static string GetQuestionText()
        => "I have tomato and lettuce only. What meal can I do with these?";
}