using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    enum ExamResultType { SUCCEDED, WITHDRAWN, FAILED, DECLINED };
    interface IExamResult
    {
        ExamResultType ResultType { get; }
        bool CumLaude { get; }
        int? Result { get; }
    }
}
