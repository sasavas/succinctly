using Domain.Features.QuestionFeature;
using Domain.Features.UserFeature;
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
            .Property(question => question.UserId)
            .HasConversion(
                userId => userId.Value,
                value => new UserId(value));

        builder.HasMany(question => question.UserLikes);

        builder.HasMany(question => question.TagIds);

        builder
            .HasMany<OpenAnswer>(question => question.Answers)
            .WithOne(answer => answer.Question)
            .OnDelete(DeleteBehavior.Cascade);
    }
}