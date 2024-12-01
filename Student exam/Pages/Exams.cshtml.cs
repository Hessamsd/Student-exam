using Application;
using Domin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Student_exam.Pages
{
    public class ExamsModel : PageModel
    {
        private readonly IApplication _application;

        public ExamsModel(IApplication application)
        {
            _application = application;
        }

        public List<Exam> Exams { get; set; } 

        [BindProperty]
        public Dictionary<int, List<int>> Answers { get; set; }

        public async Task OnGetAsync()
        {
            
            Exams = await _application.GetAllExamsAsync();
        }

        public async Task<IActionResult> OnPostAsync(int examId)
        {
            var studentId = 1;
            var success = await _application.SubmitAnswersAsync(examId, studentId, Answers);

            if (success)
            {
                return RedirectToPage("ExamSubmitted");
            }

            return Page();
        }
    }
}
