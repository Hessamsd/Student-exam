using Domin.Models;

namespace Application
{
    public interface IApplication
    {
        Task<Exam> GetExamByIdAsync(int examId);
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<bool> SubmitAnswersAsync(int examId, int studentId, Dictionary<int, List<int>> answers);

    }
}
