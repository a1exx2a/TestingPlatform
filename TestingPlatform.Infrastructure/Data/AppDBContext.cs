using Microsoft.EntityFrameworkCore;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public DbSet<Users> Users => Set<Users>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Project> Projects => Set<Project>();   
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Direction> Directions => Set<Direction>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();
    public DbSet<Attempt> Attepmts => Set<Attempt>();
    public DbSet<UserAttemptAnswer> UserAttemptAnswers => Set<UserAttemptAnswer>();
    public DbSet<UserSelectedOption> UserSelectedOptions => Set<UserSelectedOption>();
    public DbSet<UserTextAnswer> UserTextAnswers => Set<UserTextAnswer>();
    public DbSet<TestResult> TextResults => Set<TestResult>();

    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options){ }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.Login).IsUnique();
            e.HasIndex(x => x.Email).IsUnique();
            e.Property(x => x.Login).IsRequired();
            e.Property(x => x.Email).IsRequired();
            e.Property(x => x.PasswordHash).IsRequired();
            e.Property(x => x.Role).HasConversion<string>();
            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.HasOne(x => x.Student)
                .WithOne(s => s.User)   
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Student>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Phone).HasMaxLength(30).IsRequired(); ;
            e.Property(x => x.VkProfileLink).IsRequired();
        });

        modelBuilder.Entity<Direction>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
            
        });

        modelBuilder.Entity<Course>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Project>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();
        });

        modelBuilder.Entity<Group>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired();
            e.HasIndex(x => x.Name).IsUnique();

            e.HasOne(x => x.Direction)
                .WithMany(d => d.Groups)
                .HasForeignKey(x => x.DirectionId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Course)
                .WithMany(c => c.Groups)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Project)
                .WithMany(p => p.Groups)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Question>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.TestId).IsUnique();
            e.Property(x => x.TestId).IsRequired();
            e.HasIndex(x => x.Number).IsUnique();
            e.Property(x => x.Number).IsRequired();
            e.Property(x => x.AnswerType).HasConversion<string>();
            e.HasOne(x => x.Test)
                .WithMany(c => c.Questions)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Test>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Type).HasConversion<string>();
            e.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            e.HasMany(x => x.Groups)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("test_groups"));
            e.HasMany(x => x.Students)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("test_students"));
            e.HasMany(x => x.Projects)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("test_projects"));
            e.HasMany(x => x.Courses)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("test_course"));
            e.HasMany(x => x.Directions)
                .WithMany(y => y.Tests)
                .UsingEntity(j => j.ToTable("test_directions"));
        });

        modelBuilder.Entity<Attempt>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.TestId).IsRequired();
            e.Property(x => x.StudentId).IsRequired();

            e.Property(x => x.StartedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            e.HasOne(x => x.Test)
                .WithMany(p => p.Attempts)
                .HasForeignKey(x => x.TestId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(x => x.Student)
                .WithMany(p => p.Attempts)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<UserAttemptAnswer>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => x.AttemptId).IsUnique();
            e.Property(x => x.AttemptId).IsRequired();

            e.HasIndex(x => x.QuestionId).IsUnique();
            e.Property(x => x.QuestionId).IsRequired();

            e.HasOne(x => x.Attempt)
                .WithMany(p => p.UserAttemptAnswers)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Question)
                .WithMany(p => p.UserAttemptAnswers)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TestResult>(e =>
        {
            e.HasKey(x => x.Id);

            e.HasIndex(x => x.TestId).IsUnique();
            e.Property(x => x.TestId).IsRequired();

            e.HasIndex(x => x.StudentId).IsUnique();
            e.Property(x => x.StudentId).IsRequired();

            e.HasIndex(x => x.AttemptId).IsUnique();
            e.Property(x => x.AttemptId).IsRequired();

            e.HasOne(x => x.Test)
                .WithOne(x => x.TestResult)
                .HasForeignKey<Test>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
            e.HasMany(x => x.Attempt)
                .WithOne(x => x.TestResult)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Student)
                .WithMany(x => x.TestResults)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<UserTextAnswer>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.TextAnswer).IsRequired();
            e.Property(x => x.UserAttemptAnswerId).IsRequired();

            e.HasOne(x => x.UserAttemptAnswer)
                .WithOne(x => x.UserTextAnswer)
                .HasForeignKey<UserTextAnswer>(x => x.UserAttemptAnswerId)
                .OnDelete(DeleteBehavior.Cascade);
        });




        modelBuilder.Entity<UserSelectedOption>(e =>
        {
            e.HasKey(x => x.Id);
            //e.Property(x => x.UserAttemptAnswer).IsRequired();
            e.Property(x => x.AnswerId).IsRequired();

            e.HasOne(x => x.UserAttemptAnswer)
             .WithMany(y => y.UserSelectedOptions)
             .HasForeignKey(x => x.UserAttemptAnswerId)
             .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Answer)
             .WithMany(y => y.UserSelectedOptions)
             .HasForeignKey(x => x.AnswerId)
             .OnDelete(DeleteBehavior.Restrict);

        });
        

        modelBuilder.Entity<Answer>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.Text).IsRequired();
            e.Property(x => x.IsCorrect).IsRequired();
            e.Property(x => x.QuestionId).IsRequired();

            e.HasOne(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}