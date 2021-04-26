using IUniversity.Entities;
using IUniversity.Exams;
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using static IUniversity.Exams.IExamCall;

namespace IUniversity.Test
{
    public class ExamManagerTest
    {
        private const int MAX_STUDENTS = 2;
        private const int DAYS_BEFORE_CALL = 1;

        private SampleData sd = new SampleData();
        private IExamManager examManager;

        [SetUp]
        public void Init()
        {
            examManager = new ExamManager();
        }

        [Test]
        public void TestExamCalls()
        {
            ISet<IExamCall> examCalls = new HashSet<IExamCall>();
            DateTime date = DateTime.Today.AddDays(DAYS_BEFORE_CALL);
            ICourse analisiMatematica = sd.AnalisiMatematica;
            ExamType examType = ExamType.WRITTEN;
            int maximumStudents = MAX_STUDENTS;
            IExamCall examCall = new ExamCallBuilder()
                .CallStart(date)
                .Course(analisiMatematica)
                .MaximumStudents(maximumStudents)
                .ExamType(examType)
                .Build();
            examManager.AddExamCall(date, analisiMatematica, examType, maximumStudents);
            examCalls.Add(examCall);
            Assert.True(examCalls.SetEquals(examManager.ExamCalls()));
            examManager.RemoveExamCall(examCall);
            examCalls.Clear();
            Assert.True(examCalls.SetEquals(examManager.ExamCalls()));
            Assert.False(examManager.AlreadyHeld(examCall));
            Assert.True(examManager.RegisterStudent(examCall, sd.MarioRossi));
            Assert.True(examManager.RegisterStudent(examCall, sd.LucaBianchi));
            /*
            * The maximum number of student is exceeded.
            */
            Assert.False(examManager.RegisterStudent(examCall, sd.LucianoVerdi));
            Assert.True(examManager.WithdrawStudent(examCall, sd.MarioRossi));
            /*
             *Now a student can register.
             */
            Assert.True(examManager.RegisterStudent(examCall, sd.LucianoVerdi));
            /*
             * The student already withdraw.
             */
            Assert.False(examManager.WithdrawStudent(examCall, sd.MarioRossi));
            /*
             * A particular exam call  can be added once.
             */
            Assert.Throws<InvalidOperationException>(() =>
            {
                examManager.AddExamCall(date, analisiMatematica, examType, maximumStudents);
            });
            /*
             * Same date, same course but different type is ok.
             */
            examManager.AddExamCall(date, analisiMatematica, ExamType.ORAL, maximumStudents);
        }

        [Test]
        public void TestExamReport()
        {
            ISet<IExamReport> reports = new HashSet<IExamReport>();
            IExamReport reportMarioRossi = new ExamReportBuilder().Course(sd.AnalisiMatematica)
                .Student(sd.MarioRossi).Laude(true).Build();
            IExamReport reportLucaBianchi = new ExamReportBuilder().Course(sd.AnalisiMatematica)
                    .Student(sd.LucaBianchi).Laude(true).Build();
            IExamReport failReportMarioRossi = new ExamReportBuilder().Course(sd.AnalisiMatematica)
                    .Student(sd.MarioRossi).ResultType(ExamResultType.WITHDRAWN).Build();
            IExamReport failReportLucaBianchi = new ExamReportBuilder().Course(sd.AnalisiMatematica)
                    .Student(sd.LucaBianchi).ResultType(ExamResultType.WITHDRAWN).Build();
            examManager.AddExamReport(reportMarioRossi);
            reports.Add(reportMarioRossi);
            Assert.True(reports.SetEquals(examManager.ExamReports()));
            /*
             * The student have successfully passed the exam. 
             */
            Assert.True(examManager.AlreadyReportedSuccess(reportMarioRossi));
            Assert.True(examManager.AlreadyReportedSuccess(sd.MarioRossi, sd.AnalisiMatematica));
            /*
             * The student does not have a report.
             */
            Assert.False(examManager.AlreadyReportedSuccess(reportLucaBianchi));
            Assert.False(examManager.AlreadyReportedSuccess(sd.MarioRossi, sd.Programmazione));
            /*
             * The student already have a report.
             */
            Assert.Throws<InvalidOperationException>(() =>
            {
                examManager.AddExamReport(failReportMarioRossi);
            });
            /*
             * A student can have more than one exam report for the same course only if he never succeeded.
             */
            examManager.AddExamReport(failReportLucaBianchi);
            Assert.False(examManager.AlreadyReportedSuccess(sd.LucaBianchi, sd.AnalisiMatematica));
            examManager.AddExamReport(reportLucaBianchi);
            reports.Add(reportLucaBianchi);
            reports.Add(failReportLucaBianchi);
            Assert.True(reports.SetEquals(examManager.ExamReports()));
        }
    }
}
