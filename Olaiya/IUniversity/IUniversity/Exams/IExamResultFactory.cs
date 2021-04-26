using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public interface IExamResultFactory
    {
        IExamResult SuccededCumLaude();

        IExamResult Suceeded(int result);

        IExamResult Failed(int result);

        IExamResult Withdrawn();

        IExamResult Declined(int result);
    }
}
