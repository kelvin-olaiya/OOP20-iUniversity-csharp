using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    class ExamReport : IExamReport
    {
        public ICourse Course { get; }

        public IStudent Student { get; }

        public IExamResult ExamResult { get; }

        public DateTime Date { get; }

        public ExamReport(ICourse course, IStudent student, IExamResult result, DateTime date)
        {
            Course = course;
            Student = student;
            ExamResult = result;
            Date = date;
        }
    }
}
