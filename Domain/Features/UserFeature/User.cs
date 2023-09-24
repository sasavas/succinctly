using Domain.BaseTypes;
using Domain.Features.QuestionFeature;
using Domain.Features.QuestionnaireFeature;

namespace Domain.Features.UserFeature;

public class User : Entity<Guid>
{
    public User(string firstName, string lastName, EmailAddress email, UserName userName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmailAddress Email { get; set; }
    public UserName UserName { get; set; }
    private List<OpenQuestion> _openQuestions = new();
    private List<Questionnaire> _questionnaires = new();

    public IEnumerable<OpenQuestion> OpenQuestions => _openQuestions.ToList();
    public IEnumerable<Questionnaire> Questionnaires => _questionnaires.ToList();
    
    public void AskOpenQuestion(OpenQuestion openQuestion)
    {
        _openQuestions.Add(openQuestion);
    }
    
    public void AskQuestionnaire(Questionnaire questionnaire)
    {
        _questionnaires.Add(questionnaire);
    }
}