namespace Domin.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public int GroupId { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
