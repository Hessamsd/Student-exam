using Application;
using Domin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Student_exam.Pages
{
    public class ExamDetailModel : PageModel
    {
        private readonly IApplication _application;

        public ExamDetailModel(IApplication application)
        {
            _application = application;
        }

        [BindProperty(SupportsGet = true)]
        public int ExamId { get; set; }

        public Exam Exam { get; set; }

        public async Task OnGetAsync()
        {
            if (ExamId > 0)
            {
                Exam = await _application.GetExamByIdAsync(ExamId);
            }
        }
    }
}

