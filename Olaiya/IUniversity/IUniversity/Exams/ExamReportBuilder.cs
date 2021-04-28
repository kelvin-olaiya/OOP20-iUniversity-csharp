using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IUniversity.Exams
{
    public class ExamReportBuilder
    {
        private ICourse course;
        private IStudent student;
        private ExamResultType? resultType;
        private int? result;
        private bool cumLaude;
        private bool built;

        public ExamReportBuilder Course(ICourse course)
        {
            this.course = course;
            return this;
        }

        public ExamReportBuilder Student(IStudent student)
        {
            this.student = student;
            return this;
        }

        public ExamReportBuilder ResultType(ExamResultType resultType)
        {
            this.resultType = resultType;
            return this;
        }

        public ExamReportBuilder Result(int result)
        {
            this.result = result;
            return this;
        }

        public ExamReportBuilder Laude(bool laude)
        {
            this.cumLaude = laude;
            return this;
        }

        public IExamReport Build()
        {
            if (built)
            {
                throw new InvalidOperationException("The builder can be consumed only once");
            }
            else if (this.course is null || this.student is null)
            {
                throw new InvalidOperationException("A student and a course must be provided");
            }
            else if (!this.resultType.HasValue && !cumLaude)
            {
                throw new InvalidOperationException("A result type should be provided");
            }
            else if (!cumLaude && this.resultType.Value != ExamResultType.WITHDRAWN && this.result.HasValue)
            {
                throw new InvalidOperationException("A result should be provided");
            }
            IExamResultFactory resultFactory = new ExamResultFactory();
            IExamResult examResult = null;
            if (cumLaude)
            {
                examResult = resultFactory.SuccededCumLaude();
            }
            else
            {
                switch (this.resultType.Value)
                {
                    case ExamResultType.WITHDRAWN:
                        examResult = resultFactory.Withdrawn();
                        break;
                    case ExamResultType.SUCCEDED:
                        examResult = resultFactory.Suceeded(this.result.Value);
                        break;
                    case ExamResultType.FAILED:
                        examResult = resultFactory.Failed(this.result.Value);
                        break;
                    case ExamResultType.DECLINED:
                        examResult = resultFactory.Declined(this.result.Value);
                        break;
                    default:
                        break;
                }
            }
            built = true;
            return new ExamReport(this.course, student, examResult, DateTime.Today);
        }
    }
}
