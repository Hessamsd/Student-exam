using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.StudentName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new Student { StudentId = 1, StudentName = "حسام", GroupId = 1 },
                new Student { StudentId = 2, StudentName = "هما", GroupId = 1 },
                new Student { StudentId = 3, StudentName = "مریم", GroupId = 2 },
                new Student { StudentId = 4, StudentName = "حامد", GroupId = 2 },
                new Student { StudentId = 5, StudentName = "حدیث", GroupId = 3 }
            );


            builder.HasOne(s => s.Group) 
             .WithMany(g => g.Students) 
             .HasForeignKey(s => s.GroupId)
             .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(s => s.Answers)
                   .WithOne(a => a.Student)
                   .HasForeignKey(a => a.StudentId);
                   
        }
    }
}
