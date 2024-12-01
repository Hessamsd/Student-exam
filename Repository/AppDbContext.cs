using Domin.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructur
{
    public class AppDbContext : DbContext
    {

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Group> Groups { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
