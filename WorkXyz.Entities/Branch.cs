﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkXyz.Entities
{
    public class Branch
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public ICollection<StudentsNew> studentNew { get; set; }

    }
}
