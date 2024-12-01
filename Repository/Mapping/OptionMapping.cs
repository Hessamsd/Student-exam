using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class OptionMapping : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("Options");
            builder.HasKey(o => o.OptionId);

            builder.Property(o => o.OptionText)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasData(
                new Option { OptionId = 1, OptionText = "4", QuestionId = 1, IsChecked = true },
                new Option { OptionId = 2, OptionText = "5", QuestionId = 1, IsChecked = false },
                new Option { OptionId = 3, OptionText = "پاریس", QuestionId = 2, IsChecked = true },
                new Option { OptionId = 4, OptionText = "لندن", QuestionId = 2, IsChecked = false },
                new Option { OptionId = 5, OptionText = "شکسپیر", QuestionId = 3, IsChecked = true }
            );


            builder.HasOne(o => o.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade); 
            
        }
    }
}
