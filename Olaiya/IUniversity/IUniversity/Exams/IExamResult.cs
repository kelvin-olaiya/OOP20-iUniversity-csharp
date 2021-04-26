using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public enum ExamResultType { SUCCEDED, WITHDRAWN, FAILED, DECLINED };
    public interface IExamResult
    {
        ExamResultType ResultType { get; }
        bool CumLaude { get; }
        int? Result { get; }
    }
}
