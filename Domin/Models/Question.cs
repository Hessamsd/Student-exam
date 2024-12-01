namespace Domin.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ExamId { get; set; }
        public ICollection<Option> Options { get; set; }
    }

    public class Option
    {
        public int OptionId { get; set; }

        public string OptionText { get; set; }

        public bool IsChecked { get; set; }
    }
}