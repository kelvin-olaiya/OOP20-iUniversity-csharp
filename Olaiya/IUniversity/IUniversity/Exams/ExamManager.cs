using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace IUniversity.Exams
{
    public class ExamManager : IExamManager
    {
        private ISet<IExamCall> examCalls = new HashSet<IExamCall>();
        private ISet<IExamReport> examReports = new HashSet<IExamReport>();

        private bool AlreadyPublished(IExamCall examCall)
        {
            return ExamCalls()
                .Select(e => e)
                .Where(e => DateTime.Compare(e.Start, examCall.Start) == 0)
                .Where(e => e.Course.Equals(examCall.Course))
                .Where(e => e.Type == examCall.Type)
                .Any();
        }
        private void AddExamCall(IExamCall examCall)
        {
            if (AlreadyPublished(examCall))
            {
                throw new InvalidOperationException("An exam call with the same characteristics had already been added");
            }
            examCalls.Add(examCall);
        }
        public void AddExamCall(DateTime callStart, ICourse course, IExamCall.ExamType examType, int maximumStudents)
        {
            AddExamCall(new ExamCallBuilder()
                .CallStart(callStart)
                .Course(course)
                .ExamType(examType)
                .MaximumStudents(maximumStudents)
                .Build());
        }

        public void AddExamReport(ICourse course, IStudent student, ExamResult result, DateTime date)
        {
            AddExamReport(new ExamReport(course, student, result, date));
        }

        public void AddExamReport(IExamReport examReport)
        {
            if (AlreadyReportedSuccess(examReport))
            {
                throw new InvalidOperationException("Student already have a successful report");
            }
            this.examReports.Add(examReport);
        }

        public bool AlreadyHeld(IExamCall examCall)
        {
            return DateTime.Compare(DateTime.Today, examCall.Start) >= 0;
        }

        public bool AlreadyReportedSuccess(IExamReport examReport)
        {
            return AlreadyReportedSuccess(examReport.Student, examReport.Course);
        }

        public bool AlreadyReportedSuccess(IStudent student, ICourse course)
        {
            return ExamReports()
                .Select(r => r)
                .Where(r => r.ExamResult.ResultType == ExamResultType.SUCCEDED)
                .Where(r => r.Student.Equals(student))
                .Where(r => r.Course.Equals(course))
                .Any();
        }

        public ISet<IExamCall> ExamCalls()
        {
            return new HashSet<IExamCall>(examCalls);
        }

        public ISet<IExamReport> ExamReports()
        {
            return new HashSet<IExamReport>(examReports);
        }

        public bool RegisterStudent(IExamCall examCall, IStudent student)
        {
            RemoveExamCall(examCall);
            bool result = examCall.RegisterStudent(student);
            AddExamCall(examCall);
            return result;
        }

        public void RemoveExamCall(IExamCall examCall)
        {
            if (AlreadyHeld(examCall))
            {
                throw new InvalidOperationException("Can't remove an exam call which has been already held");
            }
            examCalls.Remove(examCall);
        }

        public bool WithdrawStudent(IExamCall examCall, IStudent student)
        {
            RemoveExamCall(examCall);
            bool result = examCall.WithdrawStudent(student);
            AddExamCall(examCall);
            return result;
        }
    }
}
