using IUniversity.Exams;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;



namespace IUniversity.Test
{
    class ExamResultFactoryTest
    {
        private const int MAX_RESULT = 30;
        private const int SUFFICIENT_RESULT = 27;
        private const int INSUFFICIENT_RESULT = 12;
        private const int OVER_RANGE_RESULT = MAX_RESULT + 1;
        private IExamResultFactory resultFactory;

        [SetUp]
        public void Init()
        {
            resultFactory = new ExamResultFactory();
        }

        [Test]
        public void TestCumLaudeExamResult()
        {
            IExamResult result = resultFactory.SuccededCumLaude();
            Assert.IsTrue(result.CumLaude);
            Assert.AreEqual(MAX_RESULT, result.Result);
            Assert.AreEqual(ExamResultType.SUCCEDED, result.ResultType);
        }

        [Test]
        public void TestSuccededExamResult()
        {
            IExamResult result = resultFactory.Suceeded(SUFFICIENT_RESULT);
            Assert.IsFalse(result.CumLaude);
            Assert.AreEqual(SUFFICIENT_RESULT, result.Result);
            Assert.AreEqual(ExamResultType.SUCCEDED, result.ResultType);
        }

        [Test]
        public void TestFailedExamResult()
        {
            IExamResult result = resultFactory.Failed(INSUFFICIENT_RESULT);
            Assert.IsFalse(result.CumLaude);
            Assert.AreEqual(INSUFFICIENT_RESULT, result.Result);
            Assert.AreEqual(ExamResultType.FAILED, result.ResultType);
        }

        [Test]
        public void TestWithdrawnExamResult()
        {
            IExamResult result = resultFactory.Withdrawn();
            Assert.IsFalse(result.CumLaude);
            Assert.AreEqual(null, result.Result);
            Assert.AreEqual(ExamResultType.WITHDRAWN, result.ResultType);
        }

        [Test]
        public void TestDeclinedExamResult()
        {
            IExamResult result = resultFactory.Declined(SUFFICIENT_RESULT);
            Assert.IsFalse(result.CumLaude);
            Assert.AreEqual(SUFFICIENT_RESULT, result.Result);
            Assert.AreEqual(ExamResultType.DECLINED, result.ResultType);
        }

        [Test]
        public void TestInvalidSuccededExamResult()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Suceeded(INSUFFICIENT_RESULT);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Suceeded(OVER_RANGE_RESULT);
            });
        }

        [Test]
        public void TestInvalidFailedExamResult()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Failed(SUFFICIENT_RESULT);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Failed(OVER_RANGE_RESULT);
            });
        }

        [Test]
        public void TestInvalidDeclinedExamResult()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Declined(INSUFFICIENT_RESULT);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                resultFactory.Declined(OVER_RANGE_RESULT);
            });
        }
    }
}
