using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IUniversity.Exams
{
    class ExamCall : IExamCall
    {
        private const int DAYS_BEFORE_CALL = 1;
        public ICourse Course { get; }
        public DateTime Start { get; }
        public int MaxStudents { get; }
        private IList<IStudent> registeredStudents = new List<IStudent>();
        private DateTime registrationStart;
        private DateTime registrationEnd;
        private IStudentRegistrationStrategy registrationStrategy;

        public ExamCall(ICourse course, DateTime start, IExamCall.ExamType type, int maxStudents, IStudentRegistrationStrategy registrationStrategy)
        {
            Course = course;
            Start = start;
            Type = type;
            MaxStudents = maxStudents;
            this.registrationStrategy = registrationStrategy;
            registrationStart = DateTime.Today;
            registrationEnd = DateTime.Today.AddDays(-DAYS_BEFORE_CALL);
        }

        public IExamCall.ExamType Type { get; }

        public IExamCall.CallStatus Status()
        {
            DateTime now = DateTime.Today;
            return DateTime.Compare(now, registrationStart) >= 0
                && DateTime.Compare(now, registrationStart) <= 0 ? IExamCall.CallStatus.OPEN : IExamCall.CallStatus.CLOSED;
        }

        public bool IsFull()
        {
            return registeredStudents.Count == MaxStudents;
        }

        public bool IsOpen()
        {
            return Status() == IExamCall.CallStatus.OPEN;
        }

        public ISet<IStudent> RegisteredStudents()
        {
            return registeredStudents.Select(s => s).ToHashSet();
        }

        public bool RegisterStudent(IStudent student)
        {
            if (IsFull() || IsOpen() || this.registeredStudents.Contains(student))
            {
                return false;
            }
            registrationStrategy.register(registeredStudents, student);
            return true;
        }

        public IList<IStudent> RegistrationList()
        {
            return new List<IStudent>(registeredStudents);
        }

        public bool WithdrawStudent(IStudent student)
        {
            if (!IsOpen())
            {
                return false;
            }
            return registeredStudents.Remove(student);
        }

    }
}
