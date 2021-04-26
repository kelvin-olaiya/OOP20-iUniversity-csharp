using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Entities
{
    public class Course : ICourse
    {
        public string Name { get; }
        public int CFU { get; }

        public Course(string name, int cfu)
        {
            this.Name = name;
            this.CFU = cfu;
        }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   Name == course.Name &&
                   CFU == course.CFU;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CFU);
        }
    }
}
