namespace Domin.Models
{
    public interface IExamRepository
    {
        Task<Exam> GetExamByIdAsync(int id);
        Task AddNewExamAsync(Exam newExam);
        Task<List<Exam>> GetAllExamAsync();
        Task<List<Exam>> GetAllExamsAsync();
        Task<List<Student>> GetStudentsWhoCompletedPartiallyAsync(int examId);
        Task<List<Student>> GetStudentsWhoDidNotTakeExamAsync(int groupId);
    }
}
