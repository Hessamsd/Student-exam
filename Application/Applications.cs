using Domin.Models;

namespace Application
{
    public class Applications : IApplication
    {

        private readonly IExamRepository _examRepository;
        private readonly IStudentRepository _studentRepository;

        public Applications(IExamRepository examRepository, IStudentRepository studentRepository)
        {
            _examRepository = examRepository;
            _studentRepository = studentRepository;
        }

        public async Task AddNewExamAsync(Exam newExam)
        {
            await _examRepository.AddNewExamAsync(newExam);
        }

        public async Task<List<Exam>> GetAllExamsAsync()
        {
            return await _examRepository.GetAllExamsAsync();
        }

        public async Task<Exam> GetExamByIdAsync(int examId)
        {
            return await _examRepository.GetExamByIdAsync(examId);
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task<bool> SubmitAnswersAsync(int examId, int studentId, Dictionary<int, List<int>> answers)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            var exam = await _examRepository.GetExamByIdAsync(examId);

            if (student == null || exam == null)
            {
                return false;
            }

            foreach (var answer in answers)
            {
                var question = exam.Questions.FirstOrDefault(q => q.QuestionId == answer.Key);
                if (question == null) continue;

                var correctAnswers = question.Options.Where(o => o.IsChecked).Select(o => o.OptionId).ToList();

                var answerText = string.Join(",", answer.Value);
                var answerDate = DateTime.Now;

                if (answer.Value.SequenceEqual(correctAnswers))
                {
                    student.Answers.Add(new Answer
                    {
                        QuestionId = answer.Key,
                        StudentId = student.StudentId,
                        AnswerText = answerText,
                        AnswerDate = answerDate
                    });
                }
            }

            await _studentRepository.SaveAsync();
            return true;
        }
    }
    
}
