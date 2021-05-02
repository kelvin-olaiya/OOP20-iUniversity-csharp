using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    ///<inheritdoc/>
    public class ExamReport : IExamReport
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
        public override bool Equals(object obj)
        {
            return obj is ExamReport report &&
                   EqualityComparer<ICourse>.Default.Equals(Course, report.Course) &&
                   EqualityComparer<IStudent>.Default.Equals(Student, report.Student) &&
                   EqualityComparer<IExamResult>.Default.Equals(ExamResult, report.ExamResult);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Course, Student, ExamResult);
        }
    }
}
