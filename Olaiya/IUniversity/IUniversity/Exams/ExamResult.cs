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

        public override bool Equals(object obj)
        {
            return obj is ExamResult result &&
                   ResultType == result.ResultType &&
                   CumLaude == result.CumLaude &&
                   Result == result.Result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ResultType, CumLaude, Result);
        }
    }
}
