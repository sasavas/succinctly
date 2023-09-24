using Domain.Features.UserFeature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder
            .Property(user => user.Email)
            .HasConversion(
                email => email.Value,
                value => new EmailAddress(value));

        builder
            .Property(user => user.UserName)
            .HasConversion(
                name => name.Value,
                value => new UserName(value));

        builder
            .HasMany(user => user.OpenQuestions)
            .WithOne(openQuestion => openQuestion.User)
            .HasForeignKey(question => question.UserId);
        
        builder
            .HasMany(user => user.Questionnaires)
            .WithOne(questionnaire => questionnaire.User)
            .HasForeignKey(questionnaire => questionnaire.UserId);
    }
}