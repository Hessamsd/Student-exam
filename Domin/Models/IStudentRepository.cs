namespace Domin.Models
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int studentId);
        Task SaveAsync();
    }
}
