using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public enum ExamResultType { SUCCEDED, WITHDRAWN, FAILED, DECLINED };
    public interface IExamResult
    {
        /// <summary>
        /// Get the result type
        /// </summary>
        ExamResultType ResultType { get; }
        /// <summary>
        /// Get if laude
        /// </summary>
        bool CumLaude { get; }
        /// <summary>
        /// Get result
        /// </summary>
        int? Result { get; }
    }
}
