using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public interface IExamReport
    {
        /// <summary>
        /// Get the course
        /// </summary>
        ICourse Course { get; }
        /// <summary>
        /// Get the student
        /// </summary>
        IStudent Student { get; }
        /// <summary>
        /// Get the ExamResult
        /// </summary>
        IExamResult ExamResult { get; }
        /// <summary>
        /// Get the date
        /// </summary>
        DateTime Date { get; }
    }
}
