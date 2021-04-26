using System;
using System.Collections.Generic;
using System.Text;

using IUniversity.Entities;

namespace IUniversity.Exams
{
    public interface IExamCall
    {
        enum CallStatus { OPEN, CLOSED }
        enum ExamType { ORAL, WRITTEN, PRACTICAL }

        ICourse Course { get; }

        ISet<IStudent> RegisteredStudents();

        IList<IStudent> RegistrationList();

        DateTime Start { get; }

        ExamType Type { get; }

        CallStatus Status();

        int MaxStudents { get; }

        bool RegisterStudent(IStudent student);

        bool WithdrawStudent(IStudent student);

        bool IsOpen();

        bool IsFull();

    }
}
