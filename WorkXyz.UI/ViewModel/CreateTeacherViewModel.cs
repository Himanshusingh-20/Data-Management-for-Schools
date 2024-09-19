using static WorkXyz.UI.Controllers.TeacherController;

namespace WorkXyz.UI.ViewModel
{
    public class CreateTeacherViewModel
    {
        public string Name { get; set; }
        public IFormFile ImagePath { get; set; }
        public List<CheckBoxTable> SubjectsList { get; set; } = new List<CheckBoxTable>();
    }
}
