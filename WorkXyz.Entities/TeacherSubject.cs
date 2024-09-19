using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Entities
{
    public class TeacherSubject
    {
        public int SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
        public int TeacherId { get; set; }
        
        public Teacher Teacher { get; set; }

    }
}
