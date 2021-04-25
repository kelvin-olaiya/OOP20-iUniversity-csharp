using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    interface IExamReport
    {
        ICourse Course { get; }
        IStudent Student { get; }
        IExamResult ExamResult { get; }
        DateTime Date { get; }
    }
}
