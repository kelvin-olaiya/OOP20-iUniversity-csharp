using IUniversity.Entities;
using IUniversity.Exams;
using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using static IUniversity.Exams.IExamCall;

namespace IUniversity.Test
{
    class ExamManagerTest
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

            Assert.False(examManager.RegisterStudent(examCall, sd.LucianoVerdi));
            Assert.True(examManager.WithdrawStudent(examCall, sd.MarioRossi));

            Assert.True(examManager.RegisterStudent(examCall, sd.LucianoVerdi));

            Assert.False(examManager.WithdrawStudent(examCall, sd.MarioRossi));

            Assert.Throws<InvalidOperationException>(() =>
            {
                examManager.AddExamCall(date, analisiMatematica, examType, maximumStudents);
            });
            examManager.AddExamCall(date, analisiMatematica, ExamType.ORAL, maximumStudents);
        }

        [Test]
        public void TestExamReport()
        {

        }
    }
}
