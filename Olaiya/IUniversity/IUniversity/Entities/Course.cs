using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    class Course : ICourse
    {
        public string Name { get; }
        public int CFU { get; }

        public Course(string name, int cfu)
        {
            this.Name = name;
            this.CFU = cfu;
        }

    }
}
