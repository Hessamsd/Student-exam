using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("Answers");
            builder.HasKey(a => a.AnswerId);

            builder.Property(a => a.AnswerText)
           .IsRequired()
           .HasMaxLength(500);

            builder.Property(a => a.AnswerDate)
                   .IsRequired();

            builder.HasData(
                new Answer { AnswerId = 1, QuestionId = 1, StudentId = 1, AnswerText = "پاسخ 1", AnswerDate = DateTime.Now },
                new Answer { AnswerId = 2, QuestionId = 2, StudentId = 1, AnswerText = "پاسخ 2", AnswerDate = DateTime.Now },
                new Answer { AnswerId = 3, QuestionId = 3, StudentId = 2, AnswerText = "پاسخ 3", AnswerDate = DateTime.Now },
                new Answer { AnswerId = 4, QuestionId = 4, StudentId = 2, AnswerText = "پاسخ 4", AnswerDate = DateTime.Now },
                new Answer { AnswerId = 5, QuestionId = 5, StudentId = 3, AnswerText = "پاسخ 5", AnswerDate = DateTime.Now }
            );


            builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);



            builder.HasOne(a => a.Student)
                   .WithMany(s => s.Answers)
                   .HasForeignKey(a => a.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
