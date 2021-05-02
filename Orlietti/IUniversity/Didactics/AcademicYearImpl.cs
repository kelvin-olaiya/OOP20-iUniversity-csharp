using System;
using IUniversity.User;

namespace IUniversity.Didactics
{
    public class AcademicYearImpl : AcademicYear
    {
        private DateTime start;
        private DateTime end;
        private DateTime firstTermStart;
        private DateTime firstTermEnd;
        private DateTime secondTermStart;
        private DateTime secondTermEnd;

        public AcademicYearImpl(DateTime start, DateTime end, DateTime firstTermStart, DateTime firstTermEnd,
            DateTime secondTermStart, DateTime secondTermEnd)
        {
            this.start = start;
            this.end = end;
            this.firstTermStart = firstTermStart;
            this.firstTermEnd = firstTermEnd;
            this.secondTermStart = secondTermStart;
            this.secondTermEnd = secondTermEnd;
        }

        public DateTime GetStart()
        {
            return this.start;
        }

        public DateTime GetEnd()
        {
            return this.end;
        }

        public DateTime GetFirstTermStart()
        {
            return this.firstTermStart;
        }

        public DateTime GetFirstTermEnd()
        {
            return this.firstTermEnd;
        }

        public DateTime GetSecondTermStart()
        {
            return this.secondTermStart;
        }

        public DateTime GetSecondTermEnd()
        {
            return this.secondTermEnd;
        }
    }
}