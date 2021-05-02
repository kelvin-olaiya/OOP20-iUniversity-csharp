using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static IUniversity.Exams.IExamCall;

namespace IUniversity.Exams
{
    /// <summary>
    /// Builder for exam calls
    /// </summary>
    public class ExamCallBuilder
    {
        private const int DAYS_BEFORE_CALL = 1;
        private int maximumStudents;
        private DateTime callStart;
        private ExamType examType;
        private ICourse course;
        private IStudentRegistrationStrategy registrationStrategy;
        private bool built;

        public ExamCallBuilder()
        {
            registrationStrategy = new StudentRegistrationStrategyFactory().AtTheEndOfList();
        }

        public ExamCallBuilder CallStart(DateTime callStart)
        {
            this.callStart = callStart;
            return this;
        }

        public ExamCallBuilder ExamType(ExamType examType)
        {
            this.examType = examType;
            return this;
        }

        public ExamCallBuilder Course(ICourse course)
        {
            this.course = course;
            return this;
        }

        public ExamCallBuilder MaximumStudents(int maximumStudents)
        {
            this.maximumStudents = maximumStudents;
            return this;
        }

        public ExamCallBuilder RegistrationStrategy(IStudentRegistrationStrategy registrationStrategy)
        {
            this.registrationStrategy = registrationStrategy;
            return this;
        }

        public ExamCall Build()
        {
            if (built)
            {
                throw new InvalidOperationException("Builder already consumed");
            }
            else if (course is null)
            {
                throw new InvalidOperationException("Arguments missing");
            }
            else if (DateTime.Compare(DateTime.Today, DateTime.Today.AddDays(DAYS_BEFORE_CALL)) >= 0)
            {
                throw new InvalidOperationException("Exam call creation is late");
            }
            built = true;
            return new ExamCall(course, callStart, examType, maximumStudents, registrationStrategy);
        }
    }
}
