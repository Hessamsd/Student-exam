namespace Domin.Models
{
    public interface IExamRepository
    {
        Task<Exam> GetExamByIdAsync(int id);
        Task<List<Exam>> GetAllExamAsync();
        Task<List<Student>> GetStudentsWhoCompletedPartiallyAsync(int examId);
        Task<List<Student>> GetStudentsWhoDidNotTakeExamAsync(int groupId);
    }
}
