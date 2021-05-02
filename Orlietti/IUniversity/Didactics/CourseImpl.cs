using System;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public class CourseImpl : Course
    {
        private string name;
        private int CFU;

        public CourseImpl(string name, int CFU)
        {
            this.name = name;
            this.CFU = CFU;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetCFU()
        {
            return this.CFU;
        }

        public override bool Equals(object obj)
        {
            return obj is CourseImpl impl &&
                   name == impl.name &&
                   CFU == impl.CFU;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, CFU);
        }
    }
}

