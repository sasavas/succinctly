using Domain.BaseTypes;
using Domain.Features.QuestionFeature;
using Domain.Features.QuestionnaireFeature;

namespace Domain.Features.UserFeature;

public class User : Entity<UserId>
{
    public User(string firstName, string lastName, EmailAddress email, UserName userName)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmailAddress Email { get; set; }
    public UserName UserName { get; set; }

    private List<OpenQuestion> OpenQuestions { get; set; } = new();
    private List<Questionnaire> Questionnaires { get; set; } = new();

    public IEnumerable<OpenQuestion> GetOpenQuestion() => OpenQuestions.ToList();
    
    public void AskOpenQuestion(OpenQuestion openQuestion)
    {
        OpenQuestions.Add(openQuestion);
    }
        
    public IEnumerable<Questionnaire> GetQuestionnaires() => Questionnaires.ToList();

    public void AskQuestionnaire(Questionnaire questionnaire)
    {
        Questionnaires.Add(questionnaire);
    }
}