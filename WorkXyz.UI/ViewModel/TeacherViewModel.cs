namespace WorkXyz.UI.ViewModel
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ProfileImage { get; set; }
        public IFormFile? ImagePath { get; set; }
        public List<CheckBoxTable> SubjectsList { get; set; } = new List<CheckBoxTable>();

    }
    public class CheckBoxTable
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Text { get; set; }
    }
}
