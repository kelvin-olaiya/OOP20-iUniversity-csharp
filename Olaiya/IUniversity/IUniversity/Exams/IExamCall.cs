using System;
using System.Collections.Generic;
using System.Text;

using IUniversity.Entities;

namespace IUniversity.Exams
{
    /// <summary>
    /// Students can be registered or withdrawn.
    /// </summary>
    public interface IExamCall
    {
        /// <summary>
        /// Status of the exam call.
        /// </summary>
        enum CallStatus { OPEN, CLOSED }
        /// <summary>
        /// Type of the exam call.
        /// </summary>
        enum ExamType { ORAL, WRITTEN, PRACTICAL }
        /// <summary>
        /// Get the course. 
        /// </summary>
        ///
        ICourse Course { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A set of registered students</returns>
        ISet<IStudent> RegisteredStudents();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of registered students</returns>
        IList<IStudent> RegistrationList();
        /// <summary>
        /// Get the exam call start
        /// </summary>
        DateTime Start { get; }
        /// <summary>
        /// get the exam call type
        /// </summary>
        ExamType Type { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The status of the exam call, if OPEN student can register</returns>
        CallStatus Status();
        /// <summary>
        /// Maximum students
        /// </summary>
        int MaxStudents { get; }
        /// <summary>
        /// Add a student to registration list
        /// </summary>
        /// <param name="student">the student to register</param>
        /// <returns></returns>
        bool RegisterStudent(IStudent student);
        /// <summary>
        /// Removes student from the registration list
        /// </summary>
        /// <param name="student">the student to withdraw</param>
        /// <returns></returns>
        bool WithdrawStudent(IStudent student);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if the exam call is open</returns>
        bool IsOpen();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true if the exam call is full</returns>
        bool IsFull();

    }
}
