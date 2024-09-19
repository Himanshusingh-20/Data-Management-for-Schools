using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Entities
{
    public class StudentsNew
    {
        public int Id { get; set; }         
        public string Name { get; set; }
        public int  BranchId { get; set; }
        public Branch Branch { get; set; }

    }
}
