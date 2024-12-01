using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domin.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }

        [ValidateNever]
        public int GroupId { get; set; }
        [ValidateNever]
        public Group Group { get; set; }

        [ValidateNever]
        public ICollection<Question> Questions { get; set; }


    }
}
