using IUniversity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static IUniversity.Exams.IExamCall;

namespace IUniversity.Exams
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExamManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A set with the published exam call</returns>
        ISet<IExamCall> ExamCalls();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A set with the published exam reports</returns>
        ISet<IExamReport> ExamReports();
        /// <summary>
        /// Publish a new exam call
        /// </summary>
        /// <param name="callStart">the date of the exam</param>
        /// <param name="course">the course of the exam call</param>
        /// <param name="examType">the type of the exam call</param>
        /// <param name="maximumStudents">the maximum number of students</param>
        void AddExamCall(DateTime callStart, ICourse course, ExamType examType, int maximumStudents);
        /// <summary>
        /// Publish a new exam report
        /// </summary>
        /// <param name="examReport">the report to add</param>
        void AddExamReport(IExamReport examReport);
        /// <summary>
        /// Publish a new exam report
        /// </summary>
        /// <param name="course">The exam report course</param>
        /// <param name="student">The exam report student</param>
        /// <param name="result">The exam report result</param>
        /// <param name="date">The date of the exam report</param>
        void AddExamReport(ICourse course, IStudent student, ExamResult result, DateTime date);
        /// <summary>
        /// Removes a published exam call
        /// </summary>
        /// <param name="examCall"></param>
        void RemoveExamCall(IExamCall examCall);
        /// <summary>
        /// Remove student from registration list
        /// </summary>
        /// <param name="examCall"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        bool WithdrawStudent(IExamCall examCall, IStudent student);
        /// <summary>
        /// Add a student to registration list
        /// </summary>
        /// <param name="examCall">the exam call to which add the student</param>
        /// <param name="student">the student to add</param>
        /// <returns>true if student is successfully added</returns>
        bool RegisterStudent(IExamCall examCall, IStudent student);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="examCall">the exam call to check</param>
        /// <returns>true if exam call has start date later than today</returns>
        bool AlreadyHeld(IExamCall examCall);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="examReport">the exam report to check</param>
        /// <returns>true if student already has a success exam report</returns>
        bool AlreadyReportedSuccess(IExamReport examReport);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="student">the student to check</param>
        /// <param name="course">the course to check</param>
        /// <returns></returns>
        bool AlreadyReportedSuccess(IStudent student, ICourse course);
    }
}
