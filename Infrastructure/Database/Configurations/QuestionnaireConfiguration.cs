using Domain.Features.QuestionnaireFeature;
using Domain.Features.TagFeature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class QuestionnaireConfiguration : IEntityTypeConfiguration<Questionnaire>
{
    public void Configure(EntityTypeBuilder<Questionnaire> builder)
    {
        builder.HasKey(questionnaire => questionnaire.Id);
        builder.Property(questionnaire => questionnaire.Id).ValueGeneratedOnAdd();

        builder
            .HasMany(question => question.Users)
            .WithMany()
            .UsingEntity(uQBuilder => uQBuilder.ToTable("user_questionnaire_likes"));

        builder
            .HasMany<TopicTag>(question => question.Tags)
            .WithMany(tag => tag.Questionnaires)
            .UsingEntity(qTBuilder => qTBuilder.ToTable("questionnaire_topic_tags"));

        builder
            .OwnsMany<QuestionnaireOption>(question => question.QuestionnaireOptions)
            .WithOwner(answer => answer.Questionnaire);
    }
}