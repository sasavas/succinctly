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

    public IEnumerable<OpenQuestion> OpenQuestions => _openQuestions.ToList();
    private List<OpenQuestion> _openQuestions = new();
    
    public IEnumerable<Questionnaire> Questionnaires => _questionnaires.ToList();
    private List<Questionnaire> _questionnaires = new();
    
    public void AskOpenQuestion(OpenQuestion openQuestion)
    {
        _openQuestions.Add(openQuestion);
    }
    
    public void AskQuestionnaire(Questionnaire questionnaire)
    {
        _questionnaires.Add(questionnaire);
    }
}