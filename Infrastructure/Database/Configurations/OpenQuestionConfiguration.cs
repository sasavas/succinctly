using Domain.Features.QuestionFeature;
using Domain.Features.QuestionFeature.Options;
using Domain.Features.TagFeature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class OpenQuestionConfiguration : IEntityTypeConfiguration<OpenQuestion>
{
    public void Configure(EntityTypeBuilder<OpenQuestion> builder)
    {
        builder.HasKey(question => question.Id);
        builder.Property(question => question.Id).ValueGeneratedOnAdd();

        builder
            .Property(question => question.CharLimitOption)
            .HasConversion(
                charLimit => charLimit.CharLimit,
                limit => new CharLimitOption((CharLimitOptions)limit));

        builder
            .HasMany(question => question.Users)
            .WithMany()
            .UsingEntity(uQBuilder => uQBuilder.ToTable("user_open_question_likes"));

        builder
            .HasMany<TopicTag>(question => question.Tags)
            .WithMany(tag => tag.OpenQuestions)
            .UsingEntity(qTBuilder => qTBuilder.ToTable("open_question_topic_tags"));

        builder
            .OwnsMany(question => question.Answers)
            .WithOwner(answer => answer.Question);
    }
}