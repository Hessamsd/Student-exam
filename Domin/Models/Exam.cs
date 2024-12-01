namespace Domin.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public  ICollection<Question> Questions { get; set; }
    }
}
