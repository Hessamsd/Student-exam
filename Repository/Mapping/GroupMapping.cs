using Domin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructur.Mapping
{
    public class GroupMapping : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Groups");
            builder.HasKey(g => g.GroupId);

            builder.Property(g => g.GroupName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasData(
                new Group { GroupId = 1, GroupName = "گروه A" },
                new Group { GroupId = 2, GroupName = "گروه B" },
                new Group { GroupId = 3, GroupName = "گروه C" }
            );

            builder.HasMany(g => g.Students)
             .WithOne(s => s.Group)
             .HasForeignKey(s => s.GroupId)
             .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(g => g.Exams)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

