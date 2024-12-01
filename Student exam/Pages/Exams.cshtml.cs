using Application;
using Domin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Student_exam.Pages
{
    public class ExamsModel : PageModel
    {
        private readonly IApplication _application;


        public Exam Exam { get; set; }
        [BindProperty]
        public Dictionary<int, List<int>> Answers { get; set; }

        public ExamsModel(IApplication application)
        {
            _application = application;
        }

        public async Task OnGetAsync(int examId)
        {
            Exam = await _application.GetExamByIdAsync(examId);
        }

        public async Task<IActionResult> OnPostAsync(int examId)
        {
            var studentId = 1; 
            var success = await _application.SubmitAnswersAsync(examId, studentId, Answers);

            if (success)
            {
                return RedirectToPage("/Exams/ExamSubmitted");
            }

            return Page();
        }
    }
}
