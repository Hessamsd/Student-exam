using Application;
using Domin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Student_exam.Pages
{
    public class AddExamModel : PageModel
    {
        private readonly IApplication _application;

        public AddExamModel(IApplication application)
        {
            _application = application;
        }

        [BindProperty]
        public Exam NewExam { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                await _application.AddNewExamAsync(NewExam);
                return RedirectToPage("Exams");
            }

            return Page();
        }
    }
}
