using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(q => q.QuestionId);

            builder.Property(q => q.QuestionText)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasData(

               new Question { QuestionId = 1, QuestionText = "۲ + ۲ برابر با چیست؟", ExamId = 1 },
               new Question { QuestionId = 2, QuestionText = "پایتخت فرانسه کجاست؟", ExamId = 2 },
               new Question { QuestionId = 3, QuestionText = "چه کسی نمایشنامه 'هملت' را نوشت؟", ExamId = 3 },
               new Question { QuestionId = 4, QuestionText = "نماد شیمیایی آب چیست؟", ExamId = 4 },
               new Question { QuestionId = 5, QuestionText = "سرعت نور چقدر است؟", ExamId = 5 }
            );


            builder.HasOne(q => q.Exam)
             .WithMany(e => e.Questions)
             .HasForeignKey(q => q.ExamId)
             .OnDelete(DeleteBehavior.Cascade);  
             



            builder.HasMany(q => q.Options)
                   .WithOne(o => o.Question)
                   .HasForeignKey(o => o.QuestionId);



            builder.HasMany(q => q.Answers)
                   .WithOne(a => a.Question)
                   .HasForeignKey(a => a.QuestionId);
                   
        }
    }
}
