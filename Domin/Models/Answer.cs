namespace Domin.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerDate { get; set; }

        public Question Question { get; set; }
        public Student Student { get; set; }
    }
}
