using Domin.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructur.Repository
{
    public class ExamRepository : IExamRepository
    {

        private AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetAllExamAsync()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam> GetExamByIdAsync(int id)
        {
            return await _context.Exams.Include(e => e.Questions).
                ThenInclude(q => q.Options).
                FirstOrDefaultAsync(e => e.ExamId == id);
        }

        public async Task<List<Student>> GetStudentsWhoCompletedPartiallyAsync(int examId)
        {
            var exam = await GetExamByIdAsync(examId);
            var students = await _context.Students.Where(x => x.Answers
            .Any(c => c.Question.ExamId == examId && c.AnswerDate > exam.StartDate 
            && c.AnswerDate < exam.StartDate
            .Add(exam.Duration))).ToListAsync();
            return students;
        }

        public async Task<List<Student>> GetStudentsWhoDidNotTakeExamAsync(int groupId)
        {
            return await _context.Students
                  .Where(d => !d.Answers.Any(a => a.Question.ExamId == groupId)).ToListAsync();   
        }
    }
}
