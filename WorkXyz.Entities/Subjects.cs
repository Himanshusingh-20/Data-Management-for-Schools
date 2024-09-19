using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Entities
{
    public class Subjects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    }
}
