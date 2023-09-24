using Domain.Features.QuestionFeature;
using Domain.Features.QuestionnaireFeature;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class SuccinctlyContext : DbContext
{
    public SuccinctlyContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OpenQuestion> OpenQuestions { get; set; } = null!;
    public DbSet<Questionnaire> Questionnaires { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new OpenQuestionConfiguration());
    }
}