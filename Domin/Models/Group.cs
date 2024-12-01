namespace Domin.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public ICollection<Student> students { get; set; }
    }
}
