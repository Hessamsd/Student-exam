namespace Domin.Models
{
    public class Option
    {
        public int OptionId { get; set; }

        public string OptionText { get; set; }

        public bool IsChecked { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}