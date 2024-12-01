using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class ExamMapping : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");
            builder.HasKey(e => e.ExamId);

            builder.Property(e => e.ExamName)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.StartDate)
                   .IsRequired();

            builder.Property(e => e.Duration)
                   .IsRequired();

            builder.HasData(
                new Exam { ExamId = 1, ExamName = "امتحان ریاضی", StartDate = DateTime.Now, Duration = TimeSpan.FromHours(1), GroupId = 1 },
                new Exam { ExamId = 2, ExamName = "امتحان جغرافیا", StartDate = DateTime.Now.AddDays(1), Duration = TimeSpan.FromHours(1), GroupId = 2 },
                new Exam { ExamId = 3, ExamName = "امتحان تاریخ", StartDate = DateTime.Now.AddDays(2), Duration = TimeSpan.FromHours(1), GroupId = 3 },
                new Exam { ExamId = 4, ExamName = "امتحان شیمی", StartDate = DateTime.Now.AddDays(3), Duration = TimeSpan.FromHours(1), GroupId = 1 },
                new Exam { ExamId = 5, ExamName = "امتحان مبانی علوم", StartDate = DateTime.Now.AddDays(4), Duration = TimeSpan.FromHours(1), GroupId = 2 }
            );



            builder.HasOne(e => e.Group)
              .WithMany(g => g.Exams)
              .HasForeignKey(e => e.GroupId)
              .OnDelete(DeleteBehavior.Restrict);




            builder.HasMany(e => e.Questions)
              .WithOne(q => q.Exam)
              .HasForeignKey(q => q.ExamId);
              

        }
    }
}


