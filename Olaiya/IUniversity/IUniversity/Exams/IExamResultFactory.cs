using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    interface IExamResultFactory
    {
        IExamResult succededCumLaude();

        IExamResult suceeded(int result);

        IExamResult failed(int result);

        IExamResult withdrawn();

        IExamResult declined(int result);
    }
}
