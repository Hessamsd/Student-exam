namespace Domin.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public ICollection<Option> Options { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}