using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    class ExamResultFactory : IExamResultFactory
    {
        private const int MAX_RESULT = 30;
        private const int SUFFICIENCY = 18;
        private IExamResult MakeEvaluation(ExamResultType resultType, int? result, bool cumLaude)
        {
            if (!result.HasValue && resultType != ExamResultType.WITHDRAWN)
            {
                throw new ArgumentException("Only withdrawn results may not have a numeric result");
            }
            else if (resultType == ExamResultType.WITHDRAWN && result.HasValue)
            {
                throw new ArgumentException("Only withdrawn can't have a numeric result");
            }
            else if (cumLaude && resultType != ExamResultType.SUCCEDED)
            {
                throw new ArgumentException("Honours may be given only if exam was succeded");
            }
            else if (cumLaude && result.Value != MAX_RESULT)
            {
                throw new ArgumentException("Honours may be given only if maximun result is given");
            }
            else if ((resultType == ExamResultType.SUCCEDED || resultType == ExamResultType.DECLINED)
                  && (result.Value < SUFFICIENCY || result.Value > MAX_RESULT))
            {
                throw new ArgumentException("An exam is succeded or declinable only if result is sufficient");
            }
            else if (resultType == ExamResultType.FAILED && (result.Value < 0 || result.Value >= SUFFICIENCY))
            {
                throw new ArgumentException("An exam is failed only if result is below sufficiency");
            }

            return new ExamResult(resultType, cumLaude, result);
        }
        public IExamResult Declined(int result)
        {
            return MakeEvaluation(ExamResultType.DECLINED, result, false);
        }

        public IExamResult Failed(int result)
        {
            return MakeEvaluation(ExamResultType.FAILED, result, false);
        }

        public IExamResult SuccededCumLaude()
        {
            return MakeEvaluation(ExamResultType.SUCCEDED, MAX_RESULT, true);
        }

        public IExamResult Suceeded(int result)
        {
            return MakeEvaluation(ExamResultType.SUCCEDED, result, false);
        }

        public IExamResult Withdrawn()
        {
            return MakeEvaluation(ExamResultType.WITHDRAWN, null, false);
        }
    }
}
