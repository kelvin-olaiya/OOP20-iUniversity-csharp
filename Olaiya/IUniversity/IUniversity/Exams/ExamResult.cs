using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    class ExamResult : IExamResult
    {
        public ExamResultType ResultType { get; }

        public bool CumLaude { get; }

        public int? Result { get; }

        public ExamResult(ExamResultType resultType, bool cumLaude, int? result)
        {
            ResultType = resultType;
            CumLaude = cumLaude;
            Result = result;
        }
    }
}
