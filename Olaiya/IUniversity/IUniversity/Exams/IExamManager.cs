using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static IUniversity.Exams.IExamCall;

namespace IUniversity.Exams
{
    public interface IExamManager
    {
        ISet<IExamCall> ExamCalls();
        ISet<IExamReport> ExamReports();
        void AddExamCall(DateTime callStart, ICourse course, ExamType examType, int maximumStudents);
        void AddExamReport(IExamReport examReport);
        void AddExamReport(ICourse course, IStudent student, ExamResult result, DateTime date);
        void RemoveExamCall(IExamCall examCall);
        bool WithdrawStudent(IExamCall examCall, IStudent student);
        bool RegisterStudent(IExamCall examCall, IStudent student);
        bool AlreadyHeld(IExamCall examCall);
        bool AlreadyReportedSuccess(IExamReport examReport);
        bool AlreadyReportedSuccess(IStudent student, ICourse course);
    }
}
