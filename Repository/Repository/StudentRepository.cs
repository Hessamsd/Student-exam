using Domin.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructur.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _studentRepository;

        public StudentRepository(AppDbContext studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.Students
                .Include(s => s.Answers) 
                .FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task SaveAsync()
        {
            await _studentRepository.SaveChangesAsync();
        }
    }
}
